using System.Collections;
using System.Collections.Generic;
using ETHotfix;
using ETModel;
using Hotfix;
using UnityEngine;

namespace ETHotfix
{
    [Event(EventIdType.InitSceneStart)]
    public class GameLogicStart : AEvent
    {
         public override void Run()
         {
             Game.Scene.GetComponent<SceneChangeComponent>().ToGameScene("Game.unity");
         }
    } 
}

