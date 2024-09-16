using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float timerDelayToReturnPool;

    float timer;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // This method is called when the sword collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy")) // Assuming the object has a tag "Target"
        {
            // Stop the sword from moving by freezing its Rigidbody2D
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;  // Disable physics interactions to "embed" the sword

            
            animator.SetBool("IsEmbedded", true);
            animator.SetBool("isReset", false);

            gameObject.transform.SetParent(collision.transform);
            gameObject.transform.eulerAngles = new Vector3(0, 0, -25f);
            
        }

    }

    private void Update()
    {
        Despawn();
    }

    private void Despawn()
    {
        timer += Time.deltaTime;
        if (timer >= timerDelayToReturnPool)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetSword()
    {
        timer = 0;
        gameObject.transform.SetParent(null);
        animator.SetBool("IsEmbedded", false);
        animator.SetBool("isReset", true);
        rb.isKinematic = false;
        


    }


}
