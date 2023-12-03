using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attack;
    public float attackSpeed;
    public float moveSpeed;
    public float maxHealth;

    private float _currentHealth;
    private void OnEnable()
    {
        _currentHealth = maxHealth;
        
    }

    private void Update()
    {

    }

    public void ChangeHealth(float damage)
    {
        _currentHealth += damage;
        if (_currentHealth <= 0)
            Dead();
    }

    private void Dead()
    {
        ObjectPool.Instance.PushObject(gameObject);
    }


}
