using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float cHealth)
    {
        slider.maxValue = cHealth;
        slider.value = cHealth;
    }

    public void SetHealth(float cHealth)
    {
        slider.value = cHealth;
    }
        
    

    
}
