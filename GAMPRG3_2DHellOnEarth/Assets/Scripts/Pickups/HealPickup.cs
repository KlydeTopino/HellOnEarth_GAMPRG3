using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : Pickup
{
    public float healPercent;
    public override void PickupEffect(Collider2D player)
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        health.currentHealth = health.currentHealth + health.maxHealth*(healPercent/100);
        Destroy(gameObject);
    }
}
