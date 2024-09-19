using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnMap : MonoBehaviour
{
    [SerializeField]
    PoolingListOfObject pooling;

    [SerializeField]
    Camera camera;

    [SerializeField]
    float positionXSpawn;

    [SerializeField]
    float positionXDespawn;

    [SerializeField]
    float timer;

    [SerializeField]
    float timerDelay = 1f;

    [SerializeField]
    List<GameObject> activeObjects = new List<GameObject>();

    [SerializeField]
    Transform Grid;
   

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //MakeMap();

    }

    
    public Transform MakeMap()
    {
        if(activeObjects.Count >= 4 && activeObjects[0].transform.position.x <= camera.transform.position.x + positionXDespawn)
        {
            // Despawn
            DespawnOldMap();

            // spawn object 
            GameObject obj = SpawnNewMap();

            SetNewPosition(obj);

            activeObjects.Add(obj);
            return obj.transform;

        }

        return null;
    }

    private GameObject SpawnNewMap()
    {
        GameObject obj = pooling.GetPoolObject();
        obj.transform.SetParent(Grid);
        return obj;
    }

    private void DespawnOldMap()
    {
        pooling.ReturnToPool(activeObjects[0]);
        activeObjects.RemoveAt(0);
    }

    private void SetNewPosition(GameObject obj)
    {
        // set position of new obj by position of the last element  
        Vector3 newPosition = obj.transform.position;
        newPosition.x = activeObjects[activeObjects.Count - 1].transform.position.x + positionXSpawn;
        newPosition.y = -1.2f;
        obj.transform.position = newPosition;
    }
}
