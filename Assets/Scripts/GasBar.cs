using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GasBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health/2;

    }
    public void increase(float health)
    {
        if(slider.value+health<=slider.maxValue)
            slider.value += health;
    }
    public void decrease(float health)
    {
        slider.value -= health;
    }
}
