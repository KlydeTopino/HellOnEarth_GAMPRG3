using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public Transform shotPos;
    public GameObject bullet;
    public int amountOfBullets;
    public float spread, bulletSpeed;
    public float fireRate;
    private bool Cooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        if(Input.GetMouseButtonDown(0))
        {
            if(Cooldown == false)
            {
                {
                    Shoot();
                    Invoke("ResetCooldown", 1.0f/fireRate);
                    Cooldown = true;
                }
            }
            
        }
    }

    void Shoot()
    {
        for (int i = 0; i < amountOfBullets; i++)
        {
            GameObject b = Instantiate(bullet, shotPos.position, shotPos.rotation);
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
            brb.velocity = (dir + pdir) * bulletSpeed;
        }
    }

    void ResetCooldown()
    {
        Cooldown = false;
    }
}
