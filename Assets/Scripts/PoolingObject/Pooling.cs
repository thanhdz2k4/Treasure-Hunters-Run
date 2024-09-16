using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pooling : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> pool;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        InitializeObjectPooling();
    }

    protected abstract void InitializeObjectPooling();

    public abstract GameObject GetPoolObject();


    public abstract void ReturnToPool(GameObject obj);
    

    
}
