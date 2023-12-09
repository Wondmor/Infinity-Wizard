
using System;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private void OnEnable()
    {
        slider = GetComponentInChildren<Slider>();
        setMaxHealth(Health.maxHealth);
    }

    private void Update()
    {
        setHealth(Health.currentHealth);
    }

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(float health)
    {
        slider.value = health;
    }
}
