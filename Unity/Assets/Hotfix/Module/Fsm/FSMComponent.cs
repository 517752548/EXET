using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETHotfix
{
    public class FSMComponent: Component
    {
        /// <summary>
        /// 固定状态
        /// </summary>
        private List<BaseState> commonStates = new List<BaseState>();

        /// <summary>
        /// 动态状态
        /// </summary>
        private List<BaseState> dynamicStates = new List<BaseState>();

        private int commonIndex = 0;

        public BaseState currentState = null;

        public void AddCommonState<T>() where T : BaseState
        {
            T t = ComponentFactory.CreateWithParent<T>(this);
            this.commonStates.Add(t);
        }

        public void StartRun()
        {
            TransState();
        }

        public void TransState()
        {
            if (this.dynamicStates.Count > 0)
            {
                this.currentState?.OnLeave();
                if (!this.commonStates.Contains(currentState))
                    currentState?.Dispose();
                this.currentState = this.dynamicStates[0];
                this.dynamicStates.RemoveAt(0);
                this.currentState?.OnEnter();
            }
            else
            {
                currentState?.OnLeave();
                if (!this.commonStates.Contains(currentState))
                    currentState?.Dispose();
                currentState = this.commonStates[this.commonIndex % this.commonStates.Count];
                commonIndex++;
                this.currentState?.OnEnter();
            }
        }

        /// <summary>
        /// 在动态状态池中获取某个状态，如果不存在，就在末尾添加一个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T Get<T>() where T : BaseState
        {
            for (int i = 0; i < dynamicStates.Count; i++)
            {
                if (this.dynamicStates[i] is T)
                {
                    return this.dynamicStates[i] as T;
                }
            }

            T t = ComponentFactory.CreateWithParent<T>(this);
            this.dynamicStates.Add(t);
            return t;
        }

        public override void Dispose()
        {
            this.commonIndex = 0;
            this.commonStates.Clear();
            dynamicStates.Clear();
            base.Dispose();
        }
    }
}