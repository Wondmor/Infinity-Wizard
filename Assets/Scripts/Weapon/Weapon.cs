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
    public float projectileNumber;
    public float projectileAngle;
    public float projectileRange;
    public float projectileSpeed ;

    protected bool isShooting;
    protected float lastShootTime;

    protected virtual void Start()
    {
        lastShootTime = Time.time;
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
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;
        //ObjectPool.Instance.PushObject(bulletPrefab);
        

        // 设置子弹的速度
        bullet.GetComponent<Projectile>().speed = projectileSpeed;
        bullet.GetComponent<Projectile>().range = projectileRange;
    }
}
