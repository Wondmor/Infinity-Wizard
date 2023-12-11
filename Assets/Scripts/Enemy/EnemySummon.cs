using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
public class EnemySummon : MonoBehaviour
{
    private Animator animator;
    private Enemy enemyAi;
    private GameObject player;

    void OnEnable()
    {
        animator = gameObject.GetComponent<Animator>();
        enemyAi = gameObject.GetComponent<Enemy>();
        targetHealth = enemyAi.maxHealth / 2;
    }

    private int DashCount;
    private float timer;

    private float targetHealth;
    void Update()
    {
        
        if (enemyAi._currentHealth < targetHealth)
        {
            targetHealth = -10000;
            StartCoroutine(Summon());
        }

    }

    private AIPath aiPath;
    private Flip flip;
    private BoxCollider2D boxCollider2D;
    private CapsuleCollider2D capsuleCollider2D;
    private EnemyDash enemyDash;
    public GameObject prefabToSpawn;
    IEnumerator Summon()
    {
        if ((enemyAi = gameObject.GetComponent<Enemy>()) != null)
        {
            enemyAi.enabled = false;
        }
        if ((aiPath = gameObject.GetComponent<AIPath>()) != null)
        {
            aiPath.enabled = false;
        }
        if ((flip = gameObject.GetComponent<Flip>()) != null)
        {
            flip.enabled = false;
        }
        if ((boxCollider2D = gameObject.GetComponent<BoxCollider2D>()) != null)
        {
            boxCollider2D.enabled = false;
        }
        if ((capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>()) != null)
        {
            capsuleCollider2D.enabled = false;
        }
        if ((enemyDash = gameObject.GetComponent<EnemyDash>()) != null)
        {
            enemyDash.enabled = false;
        }
        
        animator.Play("victory");
        for (int i = 0; i < spawnNumber; i++)
        {
            yield return new WaitForSeconds(1);
            Vector3 randSpawnPosition = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0f);
            randSpawnPosition += gameObject.transform.position;
            Spawn(prefabToSpawn, randSpawnPosition);
        }
        animator.Play("attack");
        
        if ((enemyAi = gameObject.GetComponent<Enemy>()) != null)
        {
            enemyAi.enabled = true;
        }
        if ((aiPath = gameObject.GetComponent<AIPath>()) != null)
        {
            aiPath.enabled = true;
        }
        if ((flip = gameObject.GetComponent<Flip>()) != null)
        {
            flip.enabled = true;
        }
        if ((boxCollider2D = gameObject.GetComponent<BoxCollider2D>()) != null)
        {
            boxCollider2D.enabled = true;
        }
        if ((capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>()) != null)
        {
            capsuleCollider2D.enabled = true;
        }
        if ((enemyDash = gameObject.GetComponent<EnemyDash>()) != null)
        {
            enemyDash.enabled = true;
            enemyDash.timeToDash = 3;
        }
        
        yield return null;
    }

    public int spawnNumber;
    private float _lastSpawnTime;
    void Spawn(GameObject spawnPrefab, Vector3 spawnPosition)
    {
        GameObject newGameObject = ObjectPool.Instance.GetObject(spawnPrefab);
        newGameObject.transform.position = spawnPosition;

        _lastSpawnTime = Time.time;
    }
}
