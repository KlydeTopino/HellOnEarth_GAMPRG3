using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public Gun gunScript;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PickupEffect();
        }
    }
    void PickupEffect()
    {
        gunScript = GameObject.FindWithTag("Current Gun").GetComponent<Gun>();
        gunScript.RefillAmmo();
        Destroy(gameObject);
    }
}
