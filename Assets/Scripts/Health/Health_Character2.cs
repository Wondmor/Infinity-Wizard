using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClearSky
{
    public class Health_Character2 : MonoBehaviour
    {
        Animator anim;
        public HealrhBar_Character2 healthbar;
        public Text healthText;

        public int maxHealth = 10;
        public int currentHealth;
        private DemoCollegeStudentController playerController;

        private void Start()
        {
            currentHealth = maxHealth;
            playerController = GetComponent<DemoCollegeStudentController>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                TakeDamage(1); // You can adjust the damage value as needed
            }

            if (currentHealth <= 0)
            {
                Die();
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
    }
}

