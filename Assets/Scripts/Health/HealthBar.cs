using UnityEngine;
using UnityEngine.UI;

namespace ClearSky
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public Transform followTransform;

        private void Start()
        {
            
        }

        private void Update()
        {
            slider.maxValue = Health.maxHealth;
            slider.value = Health.currentHealth;

            // Update the position of the health bar to follow the character
            Vector3 targetPosition = Camera.main.WorldToScreenPoint(followTransform.position);
            transform.position = targetPosition;

        }
    }
}