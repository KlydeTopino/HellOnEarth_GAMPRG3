using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Slider HealthSlider;

    public HealthBar healthBar;

    public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth == 0)
        {
            GameOverScreen.SetActive(true);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        HealthSlider.value = currentHealth;
    }
}
