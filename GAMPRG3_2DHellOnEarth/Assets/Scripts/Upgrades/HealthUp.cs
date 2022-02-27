using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : Upgrade
{
    PlayerHealth player;
    public int healthUpgrade = 50;

    public override void Effect()
    {
        player.maxHealth =+ healthUpgrade;
    }
}
