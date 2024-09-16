using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSword : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform player;
    [SerializeField] PoolingObject PoolingSwords;
   
   
    public void Spawn()
    {
        GameObject newObj = PoolingSwords.GetPoolObject();
        newObj.GetComponent<Sword>().ResetSword();
        newObj.transform.position = player.transform.position;
        newObj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }
}
