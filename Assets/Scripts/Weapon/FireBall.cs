using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Weapon
{

    public GameObject bulletPrefab; // 子弹预制体
    public Transform shootPoint;   // 发射点

    void Update()
    {
        // 在按下空格键时发射子弹
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // 实例化子弹并设置位置和朝向
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        // 设置子弹的速度
        bullet.GetComponent<Projectile>().speed = 10f;
    }
}
