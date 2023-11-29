using UnityEngine;

namespace ClearSky
{
    public class Weapon : MonoBehaviour
    {
        public Transform playerTransform; // Reference to the player's transform
        public Transform shootingPoint;   // Point from where the ammunition will be shot
        public GameObject ammunitionPrefab;
        public float rotationSpeed = 5f;
        public float shootingCooldown = 0.5f;

        private float lastShootTime;

        void Update()
        {
            // Follow the mouse with smooth rotation
            RotateTowardsMouse();

            // Check if the mouse is pressed and cooldown is over
            if (Input.GetMouseButton(0) && Time.time - lastShootTime > shootingCooldown)
            {
                Shoot();
            }
        }

        void RotateTowardsMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new Vector2(
                mousePosition.x - playerTransform.position.x,
                mousePosition.y - playerTransform.position.y
            );

            transform.up = direction;
        }

        void Shoot()
        {
            lastShootTime = Time.time;

            // Create and shoot ammunition
            GameObject ammunition = Instantiate(ammunitionPrefab, shootingPoint.position, transform.rotation);
            // You may need to add force, velocity, or other properties to the ammunition based on your game mechanics
        }
    }
}
