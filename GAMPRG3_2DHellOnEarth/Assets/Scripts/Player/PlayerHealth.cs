using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 50 + (gameObject.GetComponent<PlayerStats>().vitality * 5);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = 50 + (gameObject.GetComponent<PlayerStats>().vitality * 5);

        if (currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }
}
