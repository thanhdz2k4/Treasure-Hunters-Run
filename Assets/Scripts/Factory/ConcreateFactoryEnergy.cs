using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreateFactoryEnergy : Factory
{
    [SerializeField]
    Product energy;

    [SerializeField]
    PoolingObject poolingObject;
    public override IProduct GetProduct(Transform position)
    {
        Product newEnergy = null;
        GameObject instance = poolingObject.GetPoolObject();
        newEnergy = instance.GetComponent<Product>();

        // Set position for each coin
        newEnergy.transform.position = position.position;
        newEnergy.transform.SetParent(position);

        // Initialize coin
        newEnergy.Initialize();

        // Add any unique behavior to this factory
        instance.name = newEnergy.ProductName;


        return newEnergy;
    }


}
