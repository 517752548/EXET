using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BuildPlayer : Editor,IPreprocessBuildWithReport, IPostprocessBuildWithReport
{
    [MenuItem("Framework/Export Android Player")]
        static void ExportAndroidPlayer()
        {
            // keystore 路径
            PlayerSettings.Android.keystoreName = "./user.keystore";
            // one.keystore 密码
            PlayerSettings.Android.keystorePass = "letus123";

            // one.keystore 别名
            PlayerSettings.Android.keyaliasName = "letus123";
            // 别名密码
            PlayerSettings.Android.keyaliasPass = "letus123";
            var argsDic = new Dictionary<string, string>();
            var args = Environment.GetCommandLineArgs();
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android,BuildTarget.Android);
            foreach (var arg in args)
            {
                var kv = arg.Split('=');
                if (kv.Length == 2)
                {
                    argsDic.Add(kv[0], kv[1]);
                }
            }
            //PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "NEW_VERSION;");
            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            var ext = "apk";
            if (argsDic.ContainsKey("Format"))
            {
                ext = argsDic["Format"];
            }

            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "NET452;ILRuntime");
            string outpath = directory.Parent + "/build/BlockPuzzle." + ext;
            EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
            EditorUserBuildSettings.buildAppBundle = false;
            if (ext == "aab")
            {
                EditorUserBuildSettings.buildAppBundle = true;
            }
            if (argsDic.ContainsKey("BuildBundle") && bool.Parse(argsDic["BuildBundle"]))
            {
                Debug.Log("~~~~~~~~~~~~~~~~~~~~BuildBundle Start~~~~~~~~~~~~~~~~~~~~~~~~");
                Debug.Log("~~~~~~~~~~~~~~~~~~~~BuildBundle End~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            var option = BuildOptions.None;
            EditorUserBuildSettings.androidBuildType = AndroidBuildType.Release;
            if (argsDic.ContainsKey("Config") && argsDic["Config"] == "Debug")
            {
                option = BuildOptions.Development;
                EditorUserBuildSettings.androidBuildType = AndroidBuildType.Debug;
            }
            PlayerSettings.SplashScreen.showUnityLogo = false;
            BuildPipeline.BuildPlayer(GetBuildScenes(), outpath, BuildTarget.Android, option);
        }

        [MenuItem("Framework/Build/UseILRunTime")]
        static void UseILRunTime()
        {
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "NET452;ILRuntime");
        }
        
        [MenuItem("Framework/Build/导出配置")]
        static void ExportLuaTable()
        {
            Debug.Log($"{Directory.GetParent(Application.dataPath).Parent.FullName}\\Tools\\ExcelToLua\\Excel2Lua.bat");
            Process proc = null;
            try
            {                
                proc = new Process();
                proc.StartInfo.FileName = $"{Directory.GetParent(Application.dataPath).Parent.FullName}\\Tools\\ExcelToLua\\Excel2Lua.bat";
                proc.StartInfo.Arguments = string.Format("10");
                proc.StartInfo.CreateNoWindow = false;
                
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message,ex.StackTrace.ToString());
            }
        }
        
        [MenuItem("Framework/Build/UnUseILRunTime")]
        static void UnUseILRunTime()
        {
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "NET452");
        }
        
        [MenuItem("Framework/Publish Bundle")]
        static void PublishBuild()
        {
            SFTPHelper.CleanFiles("*.*");
            AddressablesBundleBuildScript.AddFileToAddressables();
            AddressableAssetSettings.BuildPlayerContent();
            SFTPHelper.Upload("","1.0.0");
        }
        static string[] GetBuildScenes()
        {
            List<string> names = new List<string>();
            foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes)
            {
                if (e == null)
                    continue;
                if (e.enabled)
                    names.Add(e.path);
            }

            return names.ToArray();
        }
        
        public int callbackOrder { get; }
        public void OnPostprocessBuild(BuildReport report)
        {
            throw new NotImplementedException();
        }

        public void OnPreprocessBuild(BuildReport report)
        {
            throw new NotImplementedException();
        }
}
