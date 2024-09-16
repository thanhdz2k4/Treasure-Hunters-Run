using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    

    // Update is called once per frame
    void Update()
    {
       
        Despawn();

    }

    
    private void Despawn()
    {
        if(activeObjects.Count >= 4 && activeObjects[0].transform.position.x <= camera.transform.position.x + positionXDespawn)
        {
            // remove the first element form list of active objects
            pooling.ReturnToPool(activeObjects[0]);
            activeObjects.RemoveAt(0);

            // spawn object 
            GameObject obj = pooling.GetPoolObject();
            obj.transform.SetParent(Grid);

            // set position by position of the last element of list 
            Vector3 newPosition = obj.transform.position;
            newPosition.x = activeObjects[activeObjects.Count - 1].transform.position.x + positionXSpawn;
            newPosition.y = -1.2f;
            
            obj.transform.position = newPosition;

            activeObjects.Add(obj);

        }
    }
}
