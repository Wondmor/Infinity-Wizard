using System;
using System.Collections;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
public class KnightAi : Enemy 
{
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
    
    
    protected override IEnumerator Dead()
    {
        EnemyDash enemyDash = gameObject.GetComponent<EnemyDash>();
        enemyDash.enabled = false;
        Flip flip = gameObject.GetComponent<Flip>();
        flip.enabled = false;
        ParticleSystem particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        particleSystem.Play();
        player.GetComponent<LevelUPStats>().SetExperience(getExperience);
        isAlive = false;
        aiPath.maxSpeed = 0f;
        animator.Play("die");
        bodyCollider = GetComponent<CapsuleCollider2D>();
        bodyCollider.enabled = false;
        aiPath.enabled = false;
        
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Story_Final");
    }
    
}
