using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClearSky
{
    public class Health_Character2 : MonoBehaviour
    {
        static public int maxHealth = 10, currentHealth;
        private DemoCollegeStudentController playerController;

        private void Start()
        {
            currentHealth = maxHealth;
            playerController = GetComponent<DemoCollegeStudentController>();
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

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            Debug.Log("Current Health: " + currentHealth);
            playerController.Hurt();
            // Add any additional logic you need when the character takes damage (e.g., play a hurt animation).
        }

        private void Die()
        {
            // Add any logic you need when the character dies (e.g., play a death animation, disable controls).
            playerController.Die();
            currentHealth = maxHealth;
        }
    }
}

