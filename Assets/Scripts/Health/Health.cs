using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    static public float maxHealth, currentHealth;
    private SimplePlayerController playerController;

    public static event System.Action GameOver; //
    public bool hasRespawned = false; //
    Vector2 startPos; //

    void Start()
    {
        maxHealth=10f;
        currentHealth = maxHealth;
        playerController = GetComponent<SimplePlayerController>();
        _lastDamageTime = Time.time;
        startPos = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(5);
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
            StartCoroutine(PlayerHurts());
        }
    }

        public void Heal()
    {
        currentHealth = maxHealth;
    }


    public void Die()
    {
        playerController.Die();
        currentHealth = maxHealth;

        if (!hasRespawned)
            {
                StartCoroutine(Respawn());
                hasRespawned = true; // Set the flag to true so that the player cannot respawn again.\
                
            }
            else
            {
                GameOver.Invoke();
            }
    }


    IEnumerator PlayerHurts()
        {
            // Player gets hurt. Do stuff.. play anim, sound..

            if (currentHealth < 1 && hasRespawned == true) // Health is Zero!!
            {
                yield return StartCoroutine(PlayerDied()); // Hero is Dead
            }

            else
                yield return null;
        }

        //==============================================================
        // Hero is dead
        //==============================================================
        IEnumerator PlayerDied()
        {
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
            boxCollider2D.enabled = false;
            capsuleCollider2D.enabled = false;
            PopupText.Instance.Popup("You have died!", 1f, 100f); // Demo stuff!

            yield return null;
        }

        private BoxCollider2D boxCollider2D;
        private CapsuleCollider2D capsuleCollider2D;
        public IEnumerator Respawn()
        {
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
            boxCollider2D.enabled = false;
            capsuleCollider2D.enabled = false;
            yield return new WaitForSeconds(2f); // Adjust the delay as needed

            // Reset player state
            currentHealth = maxHealth;

            transform.position = startPos;
            // Additional logic for respawn (e.g., reset position, enable controls)
            // ...
            playerController.Restart();
            hasRespawned = true;
            boxCollider2D.enabled = true;
            capsuleCollider2D.enabled = true;
        }
}