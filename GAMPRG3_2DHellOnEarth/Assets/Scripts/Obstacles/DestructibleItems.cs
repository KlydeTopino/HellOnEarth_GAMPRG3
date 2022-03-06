using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleItems : MonoBehaviour
{
    public int itemHealth;
    public SpriteRenderer spriteRenderer;
    public Sprite destroyedSprite;
    public bool isDestroyed;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        itemHealth -= damage;
        if (itemHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDestroyed = true;
        Destroy(GetComponent<Collider2D>());
        spriteRenderer.sprite = destroyedSprite;
    }
}
