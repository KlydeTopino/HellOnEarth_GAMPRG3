using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;

    public float maxHealth;
    public float currentHealth;
    public PlayerScript player;
    public Gun gunScript;

    public float waitTime = 2f;

    public Slider HealthSlider;

    public HealthBar healthBar;

    public GameObject GameOverScreen;
    public GameObject HealthHud;

    public bool isDead= false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        player = gameObject.GetComponent<PlayerScript>();
        gunScript = GameObject.FindWithTag("Current Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
            //animator.SetTrigger("isDead");
            GameOverScreen.SetActive(true);
            HealthHud.SetActive(false);
            player.enabled = false;
            gunScript.enabled = false;
        }

        HealthSlider.value = currentHealth;
    }

    public void TakeDamage(float amount)
    {
        animator.SetTrigger("isHurt");
        currentHealth -= amount;
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
        isDead = true;
        GetComponent<Collider2D>().enabled = false;
    }
}
