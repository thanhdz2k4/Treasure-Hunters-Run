using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    [SerializeField]
    float timerDeath;

   /* [SerializeField]
    ParticleSystem vfxDeath;*/

    [SerializeField]
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("isplayer");
            collision.GetComponent<PlayerHealth>().GetHit(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        {
            Death();
        }
    }

    protected override void Attack()
    {
        print("ihih");
    }

    protected override void Death()
    {
        animator.SetBool("isGetHit", true);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        //
        Destroy(gameObject, 2f);
        //
    }

    protected override void GetHit()
    {
        throw new System.NotImplementedException();
    }

    
}
