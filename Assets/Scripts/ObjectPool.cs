using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects;
        public GameObject objectPrefab;
        public int poolSize;
    }

    [SerializeField]
    private Pool[] _pools = null;

    private void Awake()
    {
        for (int i = 0; i < _pools.Length; i++)
        {
            _pools[i].pooledObjects = new Queue<GameObject>();

            for (int j = 0; j < _pools[i].poolSize; j++)
            {
                GameObject obj = Instantiate(_pools[i].objectPrefab, this.transform);
                obj.SetActive(false);

                _pools[i].pooledObjects.Enqueue(obj);
            }
        }
    }

    public GameObject GetPooledObject(int objectType)
    {
        if (objectType >= _pools.Length)
        {
            return null;
        }

        GameObject obj = _pools[objectType].pooledObjects.Dequeue();

        obj.SetActive(true);

        _pools[objectType].pooledObjects.Enqueue(obj);

        return obj;
    }

    public GameObject GetPooledObject(int objectType, Vector3 startPosition)
    {
        if (objectType >= _pools.Length)
        {
            return null;
        }

        GameObject obj = _pools[objectType].pooledObjects.Dequeue();

        obj.transform.position = startPosition;

        obj.SetActive(true);

        _pools[objectType].pooledObjects.Enqueue(obj);

        return obj;
    }
}
