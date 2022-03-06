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
    public GameObject player;
    public PlayerStats stats;

    [Header("Gun Stats")]
    public int magazineSize, bulletsPerTap, totalAmmo;
    private float Offset = -90;
    public float spread, bulletSpeed, reloadTime, timeBetweenShots, timeBetweenShooting;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading, IsReloading;
    public bool allowAutoFire, infiniteAmmo;

    [Header("Gun Upgrades")]
    int bulletsPerTapIncreased, ammoLeft;
    float timeBetweenShootingReduced, spreadReduced, reloadTimeReduced;

    [Header("UI")]
    public Text ammoDisplay;
    public Text reloadText;
    public Text reloadingText;
    public Text noAmmoText;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
        ammoDisplay = GameObject.Find("BulletCount").GetComponent<Text>();
        reloadText = GameObject.Find("ReloadText").GetComponent<Text>();
        reloadingText = GameObject.Find("ReloadingText").GetComponent<Text>();
        noAmmoText = GameObject.Find("NoAmmoText").GetComponent<Text>();

        gunSprite = gameObject.GetComponent<SpriteRenderer>();
        ammoLeft = totalAmmo;
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    void UpdateStats()
    {
        spreadReduced = spread - stats.spreadReduction;
        if(spreadReduced < 0) spreadReduced = 0;
        timeBetweenShootingReduced = timeBetweenShooting - stats.timeBetweenShootingReduction;
        reloadTimeReduced = reloadTime - stats.reloadSpeedReduction;
        bulletsPerTapIncreased = bulletsPerTap + stats.bulletsPerTapIncrease;
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
        UpdateStats();
    }

    private void Inputs()
    {
        if (allowAutoFire)
            shooting = Input.GetKey(KeyCode.Mouse0); 

        else
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (bulletsLeft < magazineSize && !reloading && !IsReloading)
        {
            if (Input.GetKeyDown(KeyCode.R) && (infiniteAmmo||ammoLeft > 0))
            {
                Reload();
            }
        }
        
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTapIncreased;
            Shoot();
        }
    }

    void Shoot()
    {
        readyToShoot = false;
        {
            GameObject b = Instantiate(bullet, shotPos.position, shotPos.rotation);
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spreadReduced, spreadReduced);
            brb.velocity = (dir + pdir) * bulletSpeed;
        }

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShootingReduced);

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
        reloadingText.enabled = true;
        Invoke("ReloadFinished", reloadTimeReduced);
    }

    private void ReloadFinished()
    {
        if(!infiniteAmmo) ammoLeft -= (magazineSize - bulletsLeft);
        if(!infiniteAmmo && ammoLeft < magazineSize) bulletsLeft = ammoLeft;
        else bulletsLeft = magazineSize;
        reloading = false;
        reloadText.enabled = false;
        reloadingText.enabled = false;
    }

    private void CheckUI()
    {
        if(bulletsPerTap > 1) ammoDisplay.text = ((bulletsLeft/bulletsPerTap).ToString() + "/" + ammoLeft/bulletsPerTap);
        else ammoDisplay.text = (bulletsLeft.ToString() + "/" + ammoLeft);
        if (bulletsLeft <= magazineSize/10) reloadText.enabled = true;
        else reloadText.enabled = false;
        if(!infiniteAmmo && ammoLeft <= 0 && bulletsLeft <= 0) 
        {
            noAmmoText.enabled = true;
            reloadText.enabled = false;
        }
    }

    public void RefillAmmo()
    {
        ammoLeft = totalAmmo;
    }
    
}
