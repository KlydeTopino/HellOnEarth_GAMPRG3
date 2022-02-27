using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("References")]
    public Transform shotPos;
    public GameObject bullet;
    public SpriteRenderer gunSprite;

    [Header("Gun Stats")]
    public int magazineSize, bulletsPerTap;
    private float Offset = -90;
    public float spread, bulletSpeed, reloadTime, timeBetweenShots, timeBetweenShooting;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading, IsReloading;
    public bool allowAutoFire;

    [Header("UI")]
    public Text ammoDisplay;
    public Text reloadText;
    public Text reloadingText;

    // Start is called before the first frame update
    void Start()
    {
        gunSprite = gameObject.GetComponent<SpriteRenderer>();
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + Offset, Vector3.forward);
        if (mousePos.x < 0.0f)
        {
            gunSprite.flipX = true;
        }
        else
        {
            gunSprite.flipX = false;
        }

        Inputs();
        CheckUI();
    }

    private void Inputs()
    {
        if(allowAutoFire) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (bulletsLeft < magazineSize && !reloading && !IsReloading)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
        
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
        if (bulletsLeft <= magazineSize/10)
        {
            reloadText.gameObject.SetActive(true);
        }
        else
        {
            reloadText.gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
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
        reloadingText.gameObject.SetActive(true);
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
        reloadText.gameObject.SetActive(false);
        reloadingText.gameObject.SetActive(false);
    }

    private void CheckUI()
    {
        ammoDisplay.text = bulletsLeft.ToString();
    }
    
}
