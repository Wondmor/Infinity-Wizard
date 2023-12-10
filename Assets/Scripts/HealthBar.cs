
using System;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    public Text currentHealthTMP;
    private void OnEnable()
    {
        slider = GetComponentInChildren<Slider>();
        setInitialHealth(Health.maxHealth);
    }

    private void Update()
    {
        setHealth(Health.currentHealth);
        updateMaxHealth(Health.maxHealth);
        currentHealthTMP.text = Health.currentHealth + "/" + Health.maxHealth;
    }

    public void setInitialHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void updateMaxHealth(float health)
    {
        slider.maxValue = health;
    }

    public void setHealth(float health)
    {
        slider.value = health;
    }   
}
