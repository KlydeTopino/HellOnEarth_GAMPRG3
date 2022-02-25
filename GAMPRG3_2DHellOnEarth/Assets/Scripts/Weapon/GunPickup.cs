using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPickup : MonoBehaviour
{
    public Gun gunScript;
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    public Transform player;

    public float pickupRange;
    public float dropForce;

    public bool equipped;
    public static bool slotFull;

    public Text pickUpText;
    private bool pickUpAllowed;

    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);

        player = GameObject.FindWithTag("Player").transform;

        if(!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = true;
        }

        if(equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distanceToPlayer = player.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E) && !slotFull && pickUpAllowed)
        {
            Pickup();
            pickUpText.gameObject.SetActive(false);
        }

        if(equipped && Input.GetKeyDown(KeyCode.G)) Drop();
        if(equipped)
        {
            transform.position = player.position;
        }
    }

    private void Pickup()
    {
        equipped = true;
        slotFull = true;

        rb.isKinematic = true;
        coll.isTrigger = true;

        gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        rb.isKinematic = false;
        coll.isTrigger = true;

        gunScript.enabled = false;

        rb.AddForce(transform.up * dropForce);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }
}
