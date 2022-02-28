using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSpeedUpgrade : Upgrade
{
    public PlayerStats stats;
    public float timeReduce;

    public override void Effect()
    {
        stats.reloadSpeedReduction += timeReduce;
    }
}
