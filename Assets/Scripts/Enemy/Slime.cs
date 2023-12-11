using UnityEngine;


public class Slime : Enemy
{
    public float flashTime;
    [SerializeField] private ParticleSystem blood;

    private SpriteRenderer sr;
    private Color originalColor;
    private bool hasPlayedBlood = false; // 新增变量来追踪是否已经播放过血液粒子系统

    public float experinece_value;

    private bool getExperience = false;

    private void OnEnable()
    {
        base.OnEnable();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.material.color;
    }

    // Update is called once per frame
    private void Update()
    {
        aiPath.destination = EnemySeek();

        if (_currentHealth <= 0 && !hasPlayedBlood) // 检查是否已经播放过血液粒子系统
        {
            hasPlayedBlood = true; // 设置为true，表示已经播放过
            sr.enabled = false;
            blood.Play();
            Destroy(gameObject, 1f);
        }
    }

    public override void ChangeHealth(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0 && getExperience == false)
        {
            BoxCollider2D myBoxCollider2D;
            if ((myBoxCollider2D = GetComponent<BoxCollider2D>()) != null)
            {
                myBoxCollider2D.enabled = false;
            }
        
            CircleCollider2D myCircleCollider2D;
            if ((myCircleCollider2D = GetComponentInChildren<CircleCollider2D>()) != null)
            {
                myCircleCollider2D.enabled = false;
            }
            player.GetComponent<LevelUPStats>().SetExperience(experinece_value);
            getExperience = true;
        }

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
}