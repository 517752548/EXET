using System;
using System.Collections;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public static class PreloadHelper
    {
        public static async ETTask PreloadRes()
        {
            List<Type> types = Game.EventSystem.GetTypes();
            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof (ConfigAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                ConfigAttribute configAttribute = attrs[0] as ConfigAttribute;
                // 只加载指定的配置
                if (!configAttribute.Type.Is(AppType.ClientH))
                {
                    continue;
                }
                string configName = type.ToString().Replace("ETHotfix.", "").Replace("Category", "");
                await ETModel.Game.Scene.GetComponent<ResourcesComponent>().CacheBundleAsync($"{configName}.txt");
            }
        }

        public static async ETTask GameingPreLoad()
        {
            for (int i = 1; i < 16; i++)
            {
                await ETModel.Game.Scene.GetComponent<ResourcesComponent>().CacheBundleAsync($"ClassicCell2D_{i}.prefab");
            }

            for (int i = 61; i < 65; i++)
            {
                await ETModel.Game.Scene.GetComponent<ResourcesComponent>().CacheBundleAsync($"ClassicCell2D_{i}.prefab");
            }
            await ETModel.Game.Scene.GetComponent<ResourcesComponent>().CacheBundleAsync($"ClassicCell2D_Bomb.prefab");
        }
    }
}