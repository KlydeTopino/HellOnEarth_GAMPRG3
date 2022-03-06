using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    public void OnCollisionEnter2D(Collision2D other)
    {
        GameObject collisionGameObject = other.gameObject;
        if(other.gameObject.CompareTag("Obstacle"))
        {
            if(collisionGameObject.GetComponent<DestructibleItems>() != null)
            {
                collisionGameObject.GetComponent<DestructibleItems>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            if(collisionGameObject.GetComponent<Enemy>() != null)
            {
                collisionGameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
            else if(collisionGameObject.GetComponent<BossHealth>() != null)
            {
                collisionGameObject.GetComponent<BossHealth>().TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Boss"))
        {
            collisionGameObject.GetComponent<BossHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
