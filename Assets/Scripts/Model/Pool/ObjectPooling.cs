using System.Collections.Generic;
using UnityEngine;


namespace SecondAttempt
{
    [AddComponentMenu("Pool/ObjectPooling")]
    public class ObjectPooling 
    {
        #region Fields

        List<PoolObject> objects;
        Transform objectsParent;

        #endregion

        public void Initialize(int count, PoolObject sample, Transform objects_parent)
        {
            objects = new List<PoolObject>();
            objectsParent = objects_parent; 
            for (int i = 0; i < count; i++)
            {
                AddObject(sample, objects_parent);
            }
        }

        private void AddObject(PoolObject sample, Transform objects_parent)
        {
            GameObject temp = Object.Instantiate(sample.gameObject);
            temp.name = sample.name;
            temp.transform.SetParent(objects_parent);
            objects.Add(temp.GetComponent<PoolObject>());
            temp.SetActive(false);
        }

        public PoolObject GetObject()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].gameObject.activeInHierarchy == false)
                {
                    return objects[i];
                }
            }
            return null;
        }
    }
}