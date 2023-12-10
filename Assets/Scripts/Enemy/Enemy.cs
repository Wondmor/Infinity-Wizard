using System;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using Pathfinding;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")] public float attack;
    public float attackSpeed;
    public float moveSpeed;
    public float maxHealth;
    public float _currentHealth;
    public float viewableRange;
    [Header("Component")] private Transform target;
    protected Animator animator;
    protected AIPath aiPath;
    private bool isAlive;
    private float _lastHit;
    protected GameObject player;
    private Vector3 home;
    private CapsuleCollider2D bodyCollider;

    protected void OnEnable()
    {
        isAlive = true;
        _currentHealth = maxHealth;
        animator = gameObject.GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
        player = GameObject.FindWithTag("Player");
        home = transform.position;
    }

    protected void Update()
    {
        aiPath.destination = EnemySeek();
        
        if (aiPath.reachedDestination)
        {
            animator.SetBool("isMoving", false);
            if (Time.time - _lastHit > 1 / attackSpeed && transform.position != home)
            {
                EnemyAttack();
                _lastHit = Time.time;
            }
        }
        else
        {
            aiPath.maxSpeed = moveSpeed;
            animator.SetBool("isMoving", true);
        }
    }

    public virtual void ChangeHealth(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0 && isAlive)
            StartCoroutine(Dead());
        else if (_currentHealth > 0 && isAlive)
        {
            StartCoroutine(Wait(1f));
            animator.Play("hurt");
        }
    }

    protected IEnumerator Dead()
    {
        player.GetComponent<LevelUPStats>().SetExperience(3f);
        isAlive = false;
        aiPath.maxSpeed = 0f;
        animator.Play("die");
        bodyCollider = GetComponent<CapsuleCollider2D>();
        bodyCollider.enabled = false;
        aiPath.enabled = false;
        yield return new WaitForSeconds(1f);
        ObjectPool.Instance.PushObject(gameObject);
    }

    IEnumerator Wait(float time)
    {
        aiPath.maxSpeed = 0f;
        yield return new WaitForSeconds(time);
        aiPath.maxSpeed = moveSpeed;
    }


    protected Vector3 EnemySeek()
    {
        float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distance < viewableRange)
        {
            return player.transform.position;
        }
        
        return home;
    }

    protected virtual void EnemyAttack()
    {
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewableRange);
    }
}