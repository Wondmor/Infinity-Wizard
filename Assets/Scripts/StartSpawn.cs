using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawn : MonoBehaviour
{
    private bool hasCollided = false; // 增加一个标志变量，用于跟踪是否已经触发碰撞

    // 在碰撞发生时调用的方法
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasCollided)
        {
            SpawnPoint spawnPointScript = gameObject.GetComponent<SpawnPoint>();

            if (spawnPointScript != null)
            {
                spawnPointScript.enabled=true; // 这里假设 SpawnPoint 脚本有一个名为 Activate 的方法
                hasCollided = true; // 设置为 true，表示已经触发碰撞
            }
        }
    }

    
}
