using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float attack;
    public float attackSpeed;
    public float moveSpeed;
    public float maxHealth;

    public float _currentHealth;
    private Animator animatior;
    private NavMeshAgent navMeshAgent;
    private bool isAlive;
    private void OnEnable()
    {
        isAlive = true;
        _currentHealth = maxHealth;
        animatior = gameObject.GetComponent<Animator>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;
    }

    private void Update()
    {

    }

    public void ChangeHealth(float damage)
    {
        
        _currentHealth -= damage;
        if (_currentHealth <= 0 && isAlive)
            StartCoroutine(Dead());
        else if(_currentHealth > 0 && isAlive)
        {
            StartCoroutine(Wait());
            animatior.Play("hurt");
        }
            
    }

    IEnumerator Dead()
    {
        isAlive = false;
        navMeshAgent.speed = 0f;
        animatior.Play("die");
        yield return new WaitForSeconds(1f);
        ObjectPool.Instance.PushObject(gameObject);
    }

    IEnumerator Wait()
    {
        navMeshAgent.speed = 0f;
        yield return new WaitForSeconds(1f);
        navMeshAgent.speed = moveSpeed;
    }



}
