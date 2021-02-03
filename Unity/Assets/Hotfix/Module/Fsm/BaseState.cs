using System.Collections;
using System.Collections.Generic;
using ETHotfix;
using UnityEngine;

namespace ETHotfix
{
    public class BaseState : Entity
    {
        public virtual void OnEnter()
        {
            Log.Info($"entet {this.GetType()}");
        }

        public virtual void SetParas(params object[] paras)
        {
            
        }
        public virtual void OnLeave()
        {
            
        }
    } 
}

