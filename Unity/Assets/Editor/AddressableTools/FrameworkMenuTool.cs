using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class FrameworkMenuTool: EditorWindow
{
    private const string k_MenuItemLocation = "Framework";
    private const string k_PersistentDataPath = "Open PersistentDataPath";

    [MenuItem(k_MenuItemLocation + "/" + k_PersistentDataPath)]
    private static void OpenPersistentDataPath()
    {
        System.Diagnostics.Process.Start(Application.persistentDataPath);
        //System.Diagnostics.Process.Start(Application.persistentDataPath + "Caches/");
        System.Diagnostics.Process.Start(Application.temporaryCachePath);
        System.Diagnostics.Process.Start(Application.consoleLogPath);
    }
    
    [MenuItem("Framework/Bundle/RecreatResConst.cs")]
    public static void AddressablesFileConfig()
    {
        AddressablesBundleBuildScript.CreatConfig();
    }

    [MenuItem("Framework/Bundle/Addressables")]
        public static void AddressablesFileSelect()
        {
            AddressablesBundleBuildScript.AddFileToAddressables();
        }

        [MenuItem("Framework/Image/CopyIosToAndroid")]
        public static void ChangeAndroidImageType()
        {
            Debug.LogWarning("开始");
            UnityEngine.Object[] selectedAsset = Selection.GetFiltered(typeof (Texture), SelectionMode.DeepAssets);
            for (int i = 0; i < selectedAsset.Length; i++)
            {
                Texture2D tex = selectedAsset[i] as Texture2D;
                TextureImporter ti = (TextureImporter) TextureImporter.GetAtPath(AssetDatabase.GetAssetPath(tex));
                int size = 1024;
                TextureImporterFormat format = TextureImporterFormat.ASTC_RGBA_6x6;
                TextureImporterPlatformSettings platformTextureSettings = new TextureImporterPlatformSettings();
                platformTextureSettings.name = "Android";
                platformTextureSettings.overridden = true;
                platformTextureSettings.maxTextureSize = size;
                platformTextureSettings.format = format;
                ti.SetPlatformTextureSettings(platformTextureSettings);
                //ti.SetPlatformTextureSettings("Android", size, format);
                AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(tex));
            }
        }
    }