using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolingListOfObject : Pooling
{
    [SerializeField]
    List<GameObject> objectPrefabs;


    protected override void InitializeObjectPooling()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < objectPrefabs.Count; i++)
        {
            GameObject obj = Instantiate(objectPrefabs[i]);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }


    private GameObject GetPoolObjectRandom()
    {
        // Check No objects available in the pool
        if (pool.Count == 0)
        {
            return null; 
        }

        int random = Random.Range(0, pool.Count);

        if (!pool[random].activeInHierarchy)
        {
            GameObject obj = pool[random];
            obj.SetActive(true);
            pool.RemoveAt(random); 
            return obj; 
        }

        return null;
    }

    public override void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Add(obj);
    }

    public override GameObject GetPoolObject()
    {
         return GetPoolObjectRandom();
    }
}
