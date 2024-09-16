using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Slider HealthBar;

    [SerializeField]
    float health = 1;

    [SerializeField]
    bool isGetHit;


    [SerializeField]
    float timer;
    [SerializeField]
    float timerDelay = 2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        SetHealthbar();
        
    }


    public void GetHit(float damage)
    {
        this.health -= damage;
        isGetHit = true;
        animator.SetBool("isGetHit", true);
        SetHealthbar();
    }

    private void Update()
    {
        if(isGetHit)
        {
            timer += Time.deltaTime;
            if(timer >= timerDelay)
            {
                animator.SetBool("isGetHit", false);
                timer = 0;
                isGetHit = false;
            }

        }
    }

    private void SetHealthbar()
    {
        this.HealthBar.value = health;
    }

}
