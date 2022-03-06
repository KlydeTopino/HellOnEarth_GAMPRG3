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

    public Slider HealthSlider;

    public HealthBar healthBar;

    public GameObject GameOverScreen;
    public GameObject HealthHud;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        player = gameObject.GetComponent<PlayerScript>();
        gunScript = GameObject.FindWithTag("CurrentGun").GetComponent<Gun>();
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
            GameOverScreen.SetActive(true);
            HealthHud.SetActive(false);
            player.enabled = false;
            gunScript.enabled = false;
            animator.SetTrigger("isDead");
        }

        HealthSlider.value = currentHealth;
    }

    public void TakeDamage(float amount)
    {
        animator.SetTrigger("isHurt");
        currentHealth -= amount;
        //ResetHurtAnimation();
    }

    public void ResetHurtAnimation()
    {
        animator.ResetTrigger("isHurt");
    }
}
