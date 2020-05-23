using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public void setHealth(float health)
    {
        this.slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color =gradient.Evaluate(1f);
    }
}