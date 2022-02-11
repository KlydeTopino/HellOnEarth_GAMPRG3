using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleItems : MonoBehaviour
{
    public int ItemHealth;
    public SpriteRenderer spriteRenderer;
    public Sprite DestroyedSprite;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            ItemHealth--;
            if(ItemHealth == 0)
            {
                Destroy(GetComponent<Collider2D>());
                spriteRenderer.sprite = DestroyedSprite;
            }
        }
        
    }
}
