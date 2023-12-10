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
            targetHealth = -1;
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
        Debug.Log("Summon");
        enemyAi = gameObject.GetComponent<Enemy>();
        aiPath = gameObject.GetComponent<AIPath>();
        flip = gameObject.GetComponent<Flip>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        enemyDash = gameObject.GetComponent<EnemyDash>();
        enemyAi.enabled = false;
        flip.enabled = false;
        aiPath.enabled = false;
        boxCollider2D.enabled = false;
        capsuleCollider2D.enabled = false;
        enemyDash.enabled = false;
        animator.Play("victory");
        for (int i = 0; i < spawnNumber; i++)
        {
            yield return new WaitForSeconds(1);
            Vector3 randSpawnPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0f);
            randSpawnPosition += gameObject.transform.position;
            Spawn(prefabToSpawn, randSpawnPosition);
        }
        
        enemyAi.enabled = true;
        flip.enabled = true;
        aiPath.enabled = true;
        boxCollider2D.enabled = true;
        capsuleCollider2D.enabled = true;
        enemyDash.enabled = true;
        enemyDash.timeToDash = 3;
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
