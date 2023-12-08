using DunGen.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClearSky
{
    public class Health_Character2 : MonoBehaviour
    {
        public static event System.Action GameOver;

        Animator anim;
        public HealrhBar_Character2 healthbar;
        public ReviveBar revivetime;
        public Text healthText;

        Vector2 startPos;

        public int maxHealth = 10;
        public int currentHealth;
        private DemoCollegeStudentController playerController;

        public bool hasRespawned = false;

        private void Start()
        {
            startPos = transform.position;
            currentHealth = maxHealth;
            playerController = GetComponent<DemoCollegeStudentController>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {

            if (currentHealth <= 0 )
            {
                Die();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    TakeDamage(1); // You can adjust the damage value as needed
                }
            }
        }

        public int getCurrentHealth()
        {
            return currentHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthText.text = currentHealth.ToString("0") + "/" + maxHealth.ToString("0");
            healthbar.setHealth(currentHealth);
            Debug.Log("Current Health: " + currentHealth);
            anim.SetTrigger("hurt");
            StartCoroutine(PlayerHurts());
            // Add any additional logic you need when the character takes damage (e.g., play a hurt animation).
        }

        private void Die()
        {
            // Add any logic you need when the character dies (e.g., play a death animation, disable controls).
            playerController.Die();
            currentHealth = maxHealth;

            if (!hasRespawned)
            {
                revivetime.setReviveTime(0);
                StartCoroutine(Respawn());
                hasRespawned = true; // Set the flag to true so that the player cannot respawn again.
            }
            else
            {
                GameOver.Invoke();
            }
        }

        IEnumerator PlayerHurts()
        {
            // Player gets hurt. Do stuff.. play anim, sound..

            if (currentHealth < 1) // Health is Zero!!
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
            // Player is dead. Do stuff.. play anim, sound..
            PopupText.Instance.Popup("You have died!", 1f, 1f); // Demo stuff!

            yield return null;
        }

        public IEnumerator Respawn()
        {
            // Additional logic for respawn (e.g., play respawn animation, reset position)
            // ...

            yield return new WaitForSeconds(2f); // Adjust the delay as needed

            // Reset player state
            currentHealth = maxHealth;
            healthText.text = currentHealth.ToString("0") + "/" + maxHealth.ToString("0");
            healthbar.setHealth(currentHealth);

            transform.position = startPos;

            playerController.Restart();
            // Additional logic for respawn (e.g., reset position, enable controls)
            // ...

            hasRespawned = true;
        }
    }
}