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
            ObjectPool.Instance.PushObject(gameObject);
            _flyTime = Time.time;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 子弹碰撞到其他物体时的处理
        // 例如销毁子弹或造成伤害等
        ObjectPool.Instance.PushObject(gameObject);
    }
    
    
}