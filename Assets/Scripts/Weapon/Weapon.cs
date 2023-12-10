using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; // 子弹预制体
    public Transform shootPoint;   // 发射点
    
    [Header("Player")]
    public float attackSpeed;
    public float attackDamage;
    [Header("Projectile")]
    public int projectileNumber;
    public float projectileAngle;
    public float projectileRange;
    public float projectileSpeed ;
    [Header("Sound")] public AudioClip attackSoundClip;

    protected bool isShooting;
    protected float lastShootTime;
    protected AudioSource audioSource;
    protected virtual void OnEnable()
    {
        lastShootTime = Time.time;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    protected virtual void Update()
    {
        // 在按下空格键时发射子弹
        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }

        if (isShooting)
        {
            if (Time.time - lastShootTime > 1/attackSpeed)
            {
                
                Fire();
                lastShootTime = Time.time;
            }
            
        }
    }

    protected virtual void Fire()
    {
        int medium = projectileNumber / 2;
        for (int i = 0; i < projectileNumber; i++)
        {
            GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
            bullet.transform.position = shootPoint.position;
            if (projectileNumber % 2 == 1)
            {
                bullet.transform.rotation = shootPoint.rotation * Quaternion.AngleAxis(projectileAngle * (i - medium), Vector3.forward);
            }
            else
            {
                bullet.transform.rotation = shootPoint.rotation * Quaternion.AngleAxis(projectileAngle * (i - medium) + projectileAngle/2, Vector3.forward);
            }
            
            bullet.GetComponent<Projectile>().speed = projectileSpeed;
            bullet.GetComponent<Projectile>().range = projectileRange;
            bullet.GetComponent<Projectile>().owner = GameObject.FindWithTag("Player");
        }
        PlayAttackSound();
    }
    
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
