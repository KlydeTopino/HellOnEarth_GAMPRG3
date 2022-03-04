using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public Rigidbody2D rb;
    public int health = 500;
    private float waitTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        GetComponent<Animator>().SetTrigger("isDead");
        rb = null;
        Destroy(gameObject, waitTime);
    }
}
