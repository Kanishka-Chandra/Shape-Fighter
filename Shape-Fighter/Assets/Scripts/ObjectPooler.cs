using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool{
        public string tag;
        public GameObject prefab;
        public int size;
        
    }

    public static ObjectPooler Instance;
    public Vector3 prefabScale;
    public List <Pool> pools;
    private Dictionary <string, Queue<GameObject>> poolDictionary;

    private void Awake() 
    {
        Instance = this;        
    }

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++) 
            {
                GameObject pooledObject = Instantiate(pool.prefab);
                pooledObject.SetActive(false);
                pooledObject.transform.localScale = prefabScale;
                objectPool.Enqueue(pooledObject);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with Tag "+tag+" doesn't exist");
            return null;
        }
        GameObject spawnedobject =  poolDictionary[tag].Dequeue();

        spawnedobject.SetActive(true);
        spawnedobject.transform.position = position;
        spawnedobject.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(spawnedobject);


        return spawnedobject;
    }
}
   
