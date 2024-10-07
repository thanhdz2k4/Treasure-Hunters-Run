using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    [SerializeField]
    float timerDeath;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float timer;

    [SerializeField]
    float timerDelay = 2f;

    [SerializeField]
    bool isDeath;

    [SerializeField]
    float distanceToDespawn;

    [SerializeField]
    PoolingListOfObject poolingListOfObject;

   

    private void Start()
    {
        animator = GetComponent<Animator>();
        poolingListOfObject = GameObject.FindWithTag("PoolingEnemy").GetComponent<PoolingListOfObject>();
    }


    private void Update()
    {
        if(isDeath)
        {
            timer += Time.deltaTime;
            if (timer >= timerDelay)
            {
                gameObject.SetActive(false);
                Transform sword = gameObject.transform.Find("Sword(Clone)");
                if (sword != null)
                {
                    sword.SetParent(null);
                }
                Despawn();
                ResetEnemy();
                timer = 0;
            }   //
        }

        if(gameObject.transform.position.x <= distanceToDespawn)
        {
            Despawn();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().GetHit(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Ship"))
        {
            SaveSystem.Instance.AddKill(1);
            Death();
            
        }
    }

    protected override void Attack()
    {
        print("ihih");
    }

    protected override void Death()
    {
        animator.SetBool("isRestart", false);
        animator.SetBool("isGetHit", true);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        isDeath = true;
        //

    }

    private void Despawn()
    {
        gameObject.transform.SetParent(null);
        poolingListOfObject.ReturnToPool(gameObject);
    }

    protected override void GetHit()
    {
        throw new System.NotImplementedException();
    }

    public void ResetEnemy()
    {
        isDeath = false;
        animator.SetBool("isGetHit", false);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        animator.SetBool("isRestart", true);
    }
}
