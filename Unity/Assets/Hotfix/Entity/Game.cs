using UnityEngine;

namespace ETHotfix
{
    public static class Game
    {
        private static EventSystem eventSystem;

        public static EventSystem EventSystem
        {
            get
            {
                return eventSystem ?? (eventSystem = new EventSystem());
            }
        }

        private static EventDispatcher eventDispatcher;

        public static EventDispatcher EventDispatcher
        {
            get
            {
                if (eventDispatcher == null)
                {
                    eventDispatcher = new EventDispatcher(){Name = "EventDispatcher"};
                }

                return eventDispatcher;
            }
        }
        
        private static Scene scene;

        public static Scene Scene
        {
            get
            {
                if (scene != null)
                {
                    return scene;
                }

                scene = new Scene() { Name = "ClientH" };
                return scene;
            }
        }

        private static SceneData _data;

        public static SceneData data
        {
            get
            {
                if (_data != null)
                {
                    return _data;
                }

                _data = new SceneData();
                return _data;
            }
        }

        private static ObjectPool objectPool;

        public static ObjectPool ObjectPool
        {
            get
            {
                if (objectPool != null)
                {
                    return objectPool;
                }

                objectPool = new ObjectPool() { Name = "ClientH" };
                return objectPool;
            }
        }
        
        private static GameObjectPool gameobjectPool;

        public static GameObjectPool GameObjectPool
        {
            get
            {
                if (objectPool != null)
                {
                    return gameobjectPool;
                }

                gameobjectPool = new GameObjectPool() { Name = "GameObjectPool" };
                return gameobjectPool;
            }
        }

        public static void Close()
        {
            scene?.Dispose();
            scene = null;

            objectPool?.Dispose();
            objectPool = null;

            eventSystem = null;
        }
    }
}