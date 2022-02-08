using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PickupEffect(other);
        }
    }

    public virtual void PickupEffect(Collider2D player)
    {
        
    }
}
