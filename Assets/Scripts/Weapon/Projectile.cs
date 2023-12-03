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
        
        if (other.CompareTag("Enemy"))
        {   
            other.GetComponent<Enemy>().ChangeHealth(owner.GetComponent<Weapon>().attackDamage);
            ObjectPool.Instance.PushObject(gameObject);
        }
        
        
    }
    
    
}