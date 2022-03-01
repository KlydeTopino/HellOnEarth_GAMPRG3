using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Upgrade
{
    public PlayerHealth health;
    public HealthBar healthBar;
    public int healthUpgrade = 50;

    public override void Effect()
    {
        health.maxHealth =+ healthUpgrade;
        healthBar.SetMaxHealth(health.maxHealth);
        Debug.Log("Max Health has been increased!");
    }
}
