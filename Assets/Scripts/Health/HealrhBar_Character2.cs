using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ClearSky
{
    public class HealrhBar_Character2 : MonoBehaviour
    {
        public Slider slider;
        public Transform followTransform;

        private void Start()
        {

        }

        private void Update()
        {
            slider.maxValue = Health_Character2.maxHealth;
            slider.value = Health_Character2.currentHealth;

            // Update the position of the health bar to follow the character
            Vector3 targetPosition = Camera.main.WorldToScreenPoint(followTransform.position);
            transform.position = targetPosition;

        }
    }
}