using UnityEngine;


public class Health : MonoBehaviour
{
    static public float maxHealth = 10, currentHealth;
    private SimplePlayerController playerController;

    void Start()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<SimplePlayerController>();
        _lastDamageTime = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private float _lastDamageTime;

    public void TakeDamage(float damage)
    {
        if (Time.time - _lastDamageTime > 0.5f)
        {
            currentHealth -= damage;
            //Debug.Log("Current Health: " + currentHealth);
            playerController.Hurt();
            _lastDamageTime = Time.time;
        }
    }


    public void Die()
    {
        playerController.Die();
        currentHealth = maxHealth;
    }
}