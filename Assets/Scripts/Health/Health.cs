using UnityEngine;
using UnityEngine.UIElements;

namespace ClearSky
{
    public class Health : MonoBehaviour
    {
        static public int maxHealth = 10, currentHealth;
        private SimplePlayerController playerController;

        void Start()
        {
            currentHealth = maxHealth;
            playerController = GetComponent<SimplePlayerController>();
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

        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            Debug.Log("Current Health: " + currentHealth);
            playerController.Hurt();
        }

        public void Die()
        {
            playerController.Die();
            currentHealth = maxHealth;
        }
    }
}
