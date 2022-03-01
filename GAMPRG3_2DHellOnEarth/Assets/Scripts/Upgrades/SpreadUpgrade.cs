using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadUpgrade : Upgrade
{
    public PlayerStats stats;
    public float spreadReduceUpgrade;

    public override void Effect()
    {
        stats.spreadReduction = spreadReduceUpgrade;
        Debug.Log("Accuracy has been increased!");
    }
}
