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
            collisionGameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
