using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public int magazineSize, bulletsPerTap;
    private float Offset = -90;
    public Transform shotPos;
    public GameObject bullet;
    public float spread, bulletSpeed, reloadTime, timeBetweenShots, timeBetweenShooting;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;
    public bool allowAutoFire;

    public GameObject ReloadHud;
    public Text AmmoDisplay; 

    // Start is called before the first frame update
    void Start()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + Offset, Vector3.forward);

        Inputs();
    }

    private void Inputs()
    {
        if(allowAutoFire) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
           Reload();
        }
        
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    void Shoot()
    {
        AmmoDisplay.text = bulletsLeft.ToString();

        readyToShoot = false;
        {
            GameObject b = Instantiate(bullet, shotPos.position, shotPos.rotation);
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
            brb.velocity = (dir + pdir) * bulletSpeed;
        }

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsLeft > 0 && bulletsShot > 0)
        Invoke("Shoot", timeBetweenShots);
    }

    void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload ()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    
}
