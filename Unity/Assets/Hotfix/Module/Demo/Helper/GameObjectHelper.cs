using System;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public class GameObjectHelper
    {
        public static void CreatGameObject(GameObject ori, Transform parent,float scale = 1)
        {
           var obj = GameObject.Instantiate(ori, parent, false);
           obj.name = $"{ori.name}.prefab";
           obj.transform.localScale = Vector3.one * scale; 
        }
        
        public static GameObject CreatGameObject(GameObject ori, Transform parent,Vector2 localposition)
        {
            var obj = GameObject.Instantiate(ori, parent, false);
            obj.name = ori.name;
            obj.transform.localPosition = localposition;
            return obj;
        }
        
        public static GameObject CreatGameObject(GameObject ori, Transform parent,Vector3 localposition)
        {
            var obj = GameObject.Instantiate(ori, parent, false);
            obj.name = ori.name;
            obj.transform.localPosition = localposition;
            return obj;
        }
        

        public static async ETTask<GameObject> CreatPrefab(string prefabName,Transform parent)
        {
            await ETModel.Game.Scene.GetComponent<ResourcesComponent>().CacheBundleAsync(prefabName);
            UnityEngine.GameObject homeui = (GameObject)ETModel.Game.Scene.GetComponent<ResourcesComponent>().GetAsset(prefabName);
            homeui = UnityEngine.Object.Instantiate(homeui,parent,false);
            homeui.name = prefabName;
            return homeui;
        }
        

    }
}