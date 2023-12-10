using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Util;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // 子弹速度
    public float range = 10f;

    public GameObject owner;
    private float _flyTime;
    
    private void OnEnable()
    {
        _flyTime = Time.time;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // 子弹沿着前方方向移动
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (Time.time - _flyTime > range / speed)
        {
            _flyTime = Time.time;
            ObjectPool.Instance.PushObject(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && owner.CompareTag("Player"))
        {   
            other.GetComponent<Enemy>().ChangeHealth(owner.GetComponent<Weapon>().attackDamage);
            ObjectPool.Instance.PushObject(gameObject);
        }
        else if (other.CompareTag("Player") && owner.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().TakeDamage(owner.GetComponent<Enemy>().attack);
            ObjectPool.Instance.PushObject(gameObject);
        }
        else if (other.CompareTag("Tile"))
        {
            ObjectPool.Instance.PushObject(gameObject);
        }

        
    }
    [Header("Sound")] public AudioClip attackSoundClip;
    protected AudioSource audioSource;
    public float startTime ;
    void PlayAttackSound()
    {
        audioSource.Stop();
        // 检查是否指定了攻击时的音效
        if (attackSoundClip != null)
        {
            // 播放音效
            audioSource.clip = attackSoundClip;
            audioSource.time = startTime;
            audioSource.Play();
        }
    }
    
}