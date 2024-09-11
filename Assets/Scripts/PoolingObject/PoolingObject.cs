using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolingObject : MonoBehaviour
{
    [SerializeField]
    List<GameObject> objectPrefabs;


    [SerializeField]
    List<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        InitializeObjectPooling();
    }

    private void InitializeObjectPooling()
    {
        pool = new List<GameObject>();
        for(int i = 0; i < objectPrefabs.Count; i++)
        {
            GameObject obj = Instantiate(objectPrefabs[i]);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObjectByIndex(int index)
    {
        if(index <= pool.Count)
        {
            if(!pool[index].activeInHierarchy)
            {
                pool[index].SetActive(true);
                return pool[index];
            }
        }
        return null;
    }

    public GameObject GetPoolObjectRandom()
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



    public void returnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Add(obj);
    }

   
}
