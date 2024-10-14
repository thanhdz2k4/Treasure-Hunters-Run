using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreateFactoryCoin : Factory
{

    [SerializeField]
    Product coin;

    [SerializeField]
    PoolingObject poolingObject;

    [SerializeField]
    int possibleQuantity;

    [SerializeField]
    [Range(1, 100)]
    int rate;


    public override IProduct GetProduct(Transform position)
    {
        int ran = Random.Range(0, 100);
        int quantity = Random.Range(0, possibleQuantity);

        // Check if random number is within the rate
        if (ran <= rate)
        {
            Product newCoin = null;  // Declare newCoin outside the loop to keep the last created coin

            for (int i = 0; i < quantity; i++)
            {
                // Create a Prefab instance and get the product component
                GameObject instance = poolingObject.GetPoolObject();
                newCoin = instance.GetComponent<Product>();

                // Set position for each coin
                newCoin.transform.position = position.position + new Vector3(i, 0, 0);
                newCoin.transform.SetParent(position);

                // Initialize coin
                newCoin.Initialize();

                // Add any unique behavior to this factory
                instance.name = newCoin.ProductName;
            }

            // Return the last coin created or null if no coins were created
            return newCoin;
        }

        return null;
    }



}
