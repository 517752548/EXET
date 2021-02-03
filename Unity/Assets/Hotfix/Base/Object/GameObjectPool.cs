using System;
using System.Collections.Generic;
using UnityEngine;

namespace ETHotfix
{
	public class GameObjectPool: Component
	{
		public string Name { get; set; }
		private UnityEngine.GameObject pool;
		
	    
        private readonly Dictionary<string, Queue<GameObject>> dictionary = new Dictionary<string, Queue<GameObject>>();

        public GameObject Fetch(string type)
        {
	        Queue<GameObject> objs;
	        GameObject obj = null;
            if (this.dictionary.TryGetValue(type, out Queue<GameObject> queue))
            {
	            if (queue.Count > 0)
	            {
		            obj = queue.Dequeue();
	            }
            }

            return obj;
        }

        public void Recycle(string type,GameObject obj)
        {
	        obj.transform.SetParent(pool.transform,false);
            if (!this.dictionary.TryGetValue(type, out Queue<GameObject> queue))
            {
                queue = new Queue<GameObject>();
                this.dictionary.Add(type, queue);
            }
            queue.Enqueue(obj);
        }
        
    }
}