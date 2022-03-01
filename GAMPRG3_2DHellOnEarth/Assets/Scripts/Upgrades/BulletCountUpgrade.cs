using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCountUpgrade : Upgrade
{
    public PlayerStats stats;
    public int bulletCountIncrease;

    public override void Effect()
    {
        stats.bulletsPerTapIncrease += bulletCountIncrease;
        Debug.Log("Bullet per shot; has been increased!");
    }
}
