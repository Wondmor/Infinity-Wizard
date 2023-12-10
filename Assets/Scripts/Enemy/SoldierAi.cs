using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAi : Enemy
{
    
    protected override void EnemyAttack()
    {
        StartCoroutine(soldierAttack());
    }

    IEnumerator soldierAttack()
    {
        Wait(0.5f);
        animator.SetTrigger("attack");
        yield return null;
    }
}
