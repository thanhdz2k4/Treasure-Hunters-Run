using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    SpawnMap spawnMap;

    [SerializeField]
    EnemyHandler enemyHandler;

    /* [SerializeField]
     PoolingListOfObject poolingObjects;
 */

    float distanceMove;

    private void Start()
    {
        distanceMove = PlayerPrefs.GetFloat("Distance");
        //if(distanceMove)
    }

    public void GetPositionToSpawnEnemy(Transform pos)
    {
        GameObject newObj = enemyHandler.GetPositionToSpawnEnemy(pos);  
        newObj.transform.SetParent(pos);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnMapAndEnemy();
    }

    private void SpawnMapAndEnemy()
    {
        Transform pos = spawnMap.MakeMap();
        if(pos != null)
        {
            Transform child = pos.Find("PositionSpawnEnemy");
            if(child != null)
            {
                GetPositionToSpawnEnemy(child);
            }
           
        }


    }
}
