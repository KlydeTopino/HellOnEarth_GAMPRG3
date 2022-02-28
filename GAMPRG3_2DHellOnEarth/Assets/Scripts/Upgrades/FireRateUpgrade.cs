using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUpgrade : Upgrade
{
    public PlayerStats stats;
    public float timeReduction;

    public override void Effect()
    {
        stats.timeBetweenShootingReduction += timeReduction;
    }
}
