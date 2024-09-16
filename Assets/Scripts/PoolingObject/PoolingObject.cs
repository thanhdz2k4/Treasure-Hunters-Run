using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : Pooling
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    int sizeOfPoolingObject;

    protected override void InitializeObjectPooling()
    {
        pool = new List<GameObject>();
        for(int i = 0; i < sizeOfPoolingObject; i++)
        {
            GameObject newObj = Instantiate(prefab);
            newObj.SetActive(false);
            pool.Add(newObj);
        }
    }
    public override GameObject GetPoolObject()
    {
        foreach(var obj in pool)
        {
            if(!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    public override void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

   

    
}
