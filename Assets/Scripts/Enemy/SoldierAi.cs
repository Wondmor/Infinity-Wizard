using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAi : Enemy
{
    
    protected override void EnemyAttack()
    {
        animator.SetTrigger("attack");
    }

}
