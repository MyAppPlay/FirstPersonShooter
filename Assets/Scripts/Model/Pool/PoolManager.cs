using UnityEngine;


namespace SecondAttempt
{
    public static class PoolManager
    {
        private static PoolPart[] pools;
        private static GameObject objectsParent;

        public static void Initialize(PoolPart[] newPools)
        {
            pools = newPools;
            objectsParent = new GameObject();
            objectsParent.name = "Pool";
            for (int i = 0; i < pools.Length; i++)
            {
                if (pools[i].PrefabPoolObj != null)
                {
                    pools[i].ObjectPooling = new ObjectPooling();
                    pools[i].ObjectPooling.Initialize(pools[i].CountObj, pools[i].PrefabPoolObj, objectsParent.transform);
                }
            }
        }

        public static GameObject GetObject(string namePrefab, Vector3 position, Quaternion rotation)
        {
            GameObject result = null;
            if (pools != null)
            {
                for (int i = 0; i < pools.Length; i++)
                {
                    if (string.Compare(pools[i].NamePrefab, namePrefab) == 0) // Null reference for empty pool 
                    {
                        {
                            result = pools[i].ObjectPooling.GetObject().gameObject;
                            result.transform.position = position;
                            result.transform.rotation = rotation;
                            result.SetActive(true);
                            return result;
                        }
                    }
                }
            }
            return result;
        }
    }
}