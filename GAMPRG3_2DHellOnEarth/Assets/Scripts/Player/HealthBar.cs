using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider;

    public void SetMaxHealth(float Health)
    {
        HealthSlider.maxValue = Health;
        HealthSlider.value = Health;
    }

    public void SetHealth(float Health)
    {
        HealthSlider.value = Health / 100;
    }
}
