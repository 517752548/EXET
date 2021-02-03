using DG.DemiEditor;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using UnityEditor;
using UnityEngine;

/// <summary>
/// SFTP操作类
/// </summary>
public partial class SFTPHelper
{
#if UNITY_IOS
    private const string localDir = "./ServerData/iOS/";
    private const string remoteDir = "/Android/Debug/";
#endif
#if UNITY_ANDROID
    private const string localDir = "./ServerData/Android/";
    private const string remoteDir = "/Android/Debug/";
#endif
    
    //这里设置为16线程，PC中较好的配置为8核16线程，设置更高意义不大
    public const int maxThread = 1;
    public static int finishCount = 0;
    public static List<string> errorMsgs = new List<string>();

    public static void CleanFiles(string pattern)
    {
        if (Directory.Exists(localDir))
        {
            var files = Directory.GetFiles(localDir, pattern);
            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
        }
    }

    public static void Upload(string buildType, string version)
    {
        var files = Directory.GetFiles(localDir);
        var path = Path.Combine(remoteDir, buildType, version);
        Put(path, files);
    }

    static void Put(string path, string[] files)
    {
        finishCount = 0;
        List<SFTPUpload> threads = new List<SFTPUpload>();
        for (int i = 0; i < maxThread; i++)
        {
            threads.Add(new SFTPUpload(i + 1));
        }

        for (int i = 0; i < files.Length; i++)
        {
            threads[i % maxThread].AddFiles(files[i]);
        }

        for (int i = 0; i < threads.Count; i++)
        {
            threads[i].Start(path);
        }
    }
}

class SFTPUpload
{
    private const string ip = "your:21";
    private const string user = "your";
    private const string pwd = "your";
    private string remoteDir;
    public float procent = 0;
    private List<string> files = new List<string>();
    private string version;
    public int current = 0;
    private int id = 0;

    public Dictionary<string, string> fileDic = new Dictionary<string, string>();

    public SFTPUpload(int id)
    {
        this.id = id;
    }

    WebClient _ftp;

    WebClient Ftp
    {
        get
        {
            if (_ftp == null)
            {
                _ftp = new WebClient();
                _ftp.Credentials = new NetworkCredential(user,pwd);
                _ftp.BaseAddress = "ftp://" + ip;
            }

            return _ftp;
        }
    }

    public void AddFiles(string file)
    {
        files.Add(file);
    }

    public void Start(string remoteDir)
    {
        this.remoteDir = remoteDir;
        Thread start = new Thread(Put);
        start.Start();
    }

    private void Put()
    {
        try
        {

            int max = files.Count;
            foreach (var path in files)
            {
                var dir = remoteDir + "/";
                Ftp.UploadFile(dir + Path.GetFileName(path),path);
                current++;
                procent = current * 100f / max;
                Debug.Log(id + "  thread  percent: " + procent);
            }
            Debug.LogError(id + "上传成功!");
        }
        catch (Exception ex)
        {
            var msg = $"{id}  thread  上传失败，原因：{ex}\n";
            Debug.LogErrorFormat(msg);
            SFTPHelper.errorMsgs.Add(msg);
        }
        Interlocked.Increment(ref SFTPHelper.finishCount);
        if (SFTPHelper.finishCount >= SFTPHelper.maxThread)
        {
            //SFTPHelper.NoticeError();
        }
    }
}