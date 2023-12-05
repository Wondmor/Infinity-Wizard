using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAi : Enemy
{

    void attack()
    {
        
    }
    
    protected override void EnemyAttack()
    {
        animator.SetTrigger("attack");
    }
    private void OnTriggerEnter2D(Collider other)
    {
        throw new NotImplementedException();
    }
}
