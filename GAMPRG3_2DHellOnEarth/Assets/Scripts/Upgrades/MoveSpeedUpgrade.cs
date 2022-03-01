using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedUpgrade : Upgrade
{
    public PlayerScript player;
    public float speedIncrease;

    public override void Effect()
    {
        player.MoveSpeed += speedIncrease;
        Debug.Log("Movement Speed has been increased!");
    }
}
