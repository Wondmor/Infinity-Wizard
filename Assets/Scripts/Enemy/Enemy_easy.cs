using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enemy_easy : MonoBehaviour
{
    public int health;
    public int damage;
    public float flashTime;
    [SerializeField] private ParticleSystem blood;

    private SpriteRenderer sr;
    private Color originalColor;
    private bool hasPlayedBlood = false; // 新增变量来追踪是否已经播放过血液粒子系统

    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.material.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0 && !hasPlayedBlood) // 检查是否已经播放过血液粒子系统
        {
            hasPlayedBlood = true; // 设置为true，表示已经播放过
            sr.enabled = false;
            blood.Play();
            Destroy(gameObject, 1f);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        FlashColor(flashTime);
    }

    void FlashColor(float time)
    {
        sr.material.color = Color.red;
        Invoke("ResetColor", time);
    }

    void ResetColor()
    {
        sr.material.color = originalColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            // 在这里添加与玩家碰撞的逻辑
        }
    }
}
