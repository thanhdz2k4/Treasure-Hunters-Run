using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] 
    PoolingListOfObject poolingObjects;


    public GameObject GetPositionToSpawnEnemy(Transform pos)
    {     
        GameObject newObj = poolingObjects.GetPoolObject();
        newObj.transform.position = pos.transform.position;
        return newObj;
    }
  
}
