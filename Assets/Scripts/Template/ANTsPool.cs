using System.Collections.Generic;
using UnityEngine;

namespace ANTs.Template
{
    public class ANTsPool : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        [SerializeField] int initialPoolSize = 10;
        [SerializeField] bool canExpand;

        private Queue<GameObject> pool;
        public GameObject GetPrefab() { return prefab; }

        public void LoadNewPrefab(GameObject prefab)
        {
            this.prefab = prefab;
            Init();
        }

        private void Awake()
        {
            if (prefab != null) Init();
        }

        private void Init()
        {
            pool = new Queue<GameObject>();
            for (int i = 0; i < initialPoolSize; i++)
            {
                CreateNewPoolObject();
            }
        }

        public GameObject GetPooledObject()
        {
            if (pool.Count == 0) CreateNewPoolObject();
            GameObject pooledObject = pool.Dequeue();

            pooledObject.SetActive(true);

            return pooledObject;
        }

        public GameObject GetPooledObject(Vector3 postition)
        {
            GameObject pooledObject = GetPooledObject();

            if (pooledObject) pooledObject.transform.position = postition;

            return pooledObject;
        }

        private void Push(GameObject pooledObj)
        {
            pool.Enqueue(pooledObj);
            pooledObj.SetActive(false);
        }

        public void ReturnToPool(GameObject pooledObj)
        {
            pooledObj.transform.SetParent(transform);
            Push(pooledObj);
        }

        private GameObject CreateNewPoolObject()
        {
            GameObject pooledObj = Instantiate(prefab);
            pooledObj.transform.SetParent(transform);

            Push(pooledObj);
            return pooledObj;
        }
    }
}



