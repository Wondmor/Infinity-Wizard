using System;
using System.Collections;
using UnityEngine;
using Pathfinding;
public class KnightAi : Enemy 
{
    private bool isAlive;
    private Vector3 home;
    
    private void Start()
    {
        _currentHealth = maxHealth;
    }
    protected override void OnEnable()
    {
        isAlive = true;
        animator = gameObject.GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
        player = GameObject.FindWithTag("Player");
        home = transform.position;
        

    }

    

    protected override void EnemyAttack()
    {
        animator.SetTrigger("attack");

    }
    
    
}
