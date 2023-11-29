using UnityEngine;
using UnityEngine.UI;

namespace ClearSky
{
    public class ExperienceBar : MonoBehaviour
    {
        public Slider slider;
        public Transform followTransform;

        private void Start()
        {
            
        }

        private void Update()
        {
            

            // Update the position of the health bar to follow the character
            //Vector3 targetPosition = Camera.main.WorldToScreenPoint(followTransform.position);
            //transform.position = targetPosition;

        }
    }
}