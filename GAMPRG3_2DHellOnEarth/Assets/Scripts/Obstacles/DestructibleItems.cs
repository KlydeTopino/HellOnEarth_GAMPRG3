using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleItems : MonoBehaviour
{
    public int itemHealth;
    public SpriteRenderer spriteRenderer;
    public Sprite destroyedSprite;

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
        Destroy(GetComponent<Collider2D>());
        spriteRenderer.sprite = destroyedSprite;
    }
    void Update()
    {
        
    }
}
