using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{

	public class SceneChangeComponent: Entity
	{
		public async void ToGameScene(string sceneName)
		{
			await ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadSceneActive(sceneName);
		}
	}
}