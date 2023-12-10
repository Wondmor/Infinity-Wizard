using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyDash : MonoBehaviour
{
    private Animator animator;
    private Enemy enemyAi;
    private GameObject player;
    
    void OnEnable()
    {
        animator = gameObject.GetComponent<Animator>();
        enemyAi = gameObject.GetComponent<Enemy>();

        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private int DashCount;
    public int timeToDash;
    private float timer;

    void Update()
    {
        player = GameObject.FindWithTag("Player");
        float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distance < enemyAi.viewableRange)
        {
            if (Time.time - timer >= 1)
            {
                DashCount += 1;
                if (DashCount >= timeToDash)
                {
                    DashCount = 0;
                    StartCoroutine(Dash());
                }

                timer = Time.time;
            }
        }
        else
        {
            DashCount = 0;
        }
    }

    private AIPath aiPath;
    private Flip flip;
    private BoxCollider2D boxCollider2D;
    private CapsuleCollider2D capsuleCollider2D;
    IEnumerator Dash()
    {
        enemyAi = gameObject.GetComponent<Enemy>();
        aiPath = gameObject.GetComponent<AIPath>();
        flip = gameObject.GetComponent<Flip>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        enemyAi.enabled = false;
        flip.enabled = false;
        aiPath.enabled = false;
        boxCollider2D.enabled = false;
        capsuleCollider2D.enabled = false;
        
        
        animator.Play("casting");
        yield return new WaitForSeconds(2);
        animator.Play("attack");
        StartCoroutine(PlayAttackSound(soundDelay,soundStartTime));
        
        Vector3 target = player.transform.position;
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target, 5f * Time.deltaTime);
            yield return null;
        }
        
        enemyAi.enabled = true;
        flip.enabled = true;
        aiPath.enabled = true;
        boxCollider2D.enabled = true;
        capsuleCollider2D.enabled = true;
        DashCount = 0;
        yield return null;
    }
    
    [Header("Sound")] public AudioClip attackSoundClip;
    protected AudioSource audioSource;
    public float soundStartTime;
    public float soundDelay;
    IEnumerator PlayAttackSound(float delay, float startTime)
    {
        audioSource.Stop();
        yield return new WaitForSeconds(delay);
        // 检查是否指定了攻击时的音效
        if (attackSoundClip != null)
        {
            // 播放音效
            audioSource.clip = attackSoundClip;
            audioSource.time = startTime;
            audioSource.Play();
        }

        yield return null;
    }
}