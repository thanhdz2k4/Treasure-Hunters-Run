using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float damage;

    protected abstract void Attack();
    protected abstract void GetHit();
    protected abstract void Death();
}
