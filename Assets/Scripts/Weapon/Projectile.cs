using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // 子弹速度

    void Update()
    {
        // 子弹沿着前方方向移动
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // 子弹碰撞到其他物体时的处理
        // 例如销毁子弹或造成伤害等
        Destroy(gameObject);
    }

}