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

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            itemHealth--;
        }
    }
    void Update()
    {
        if(itemHealth <= 0)
        {
            Destroy(GetComponent<Collider2D>());
            spriteRenderer.sprite = destroyedSprite;
        }
    }
}
