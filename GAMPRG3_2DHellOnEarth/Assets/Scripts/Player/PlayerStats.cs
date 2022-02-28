using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float timeBetweenShootingReduction { get; set; }
    public float reloadSpeedReduction { get; set;}
    public float spreadReduction { get; set;}
    public int bulletsPerTapIncrease {get; set; }
}
