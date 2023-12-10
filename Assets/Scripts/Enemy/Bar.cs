using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [field:SerializeField]
    public float MaxValue { get; private set; }
    [field:SerializeField]
    public float Value { get; private set; }

    [SerializeField] private RectTransform _healthBar;

    public Enemy enemy;

    private void OnEnable()
    {
        MaxValue = enemy.maxHealth;

    }

    private void Update()
    {
        Change(enemy._currentHealth);
    }

    public void Change(float amount)
    {
        Value = Mathf.Clamp(amount, 0, MaxValue);
        Vector2 sizeDelta = _healthBar.sizeDelta;

        // 修改宽度
        sizeDelta.x = Value;

        // 将修改后的 sizeDelta 赋值给 RectTransform
        _healthBar.sizeDelta = sizeDelta;
    }

    

}
