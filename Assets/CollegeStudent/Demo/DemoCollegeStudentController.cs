using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClearSky
{
    public class DemoCollegeStudentController : MonoBehaviour
    {
        public float movePower = 10f;

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        private bool alive = true;
        private bool isKickboard = false;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Attack();
                KickBoard();
                Move(); // Call the new Move method for handling movement.
            }
        }

        void KickBoard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (isKickboard)
                {
                    isKickboard = false;
                    anim.SetBool("isKickBoard", false);
                    // Reset the speed to the original value when kickboard is deactivated
                    movePower /= 2f;
                }
                else
                {
                    isKickboard = true;
                    anim.SetBool("isKickBoard", true);
                    // Increase speed by 10% when kickboard is activated
                    movePower *= 2f;
                }
            }
        }

        void Move()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);
            }

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                moveVelocity += Vector3.up;
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                moveVelocity += Vector3.down;
            }

            transform.position += moveVelocity * movePower * Time.deltaTime;
        }

        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("attack");
            }
        }

        public void Hurt()
        {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(0f, 0f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(0f, 0f), ForceMode2D.Impulse);
        }

        public void Die()
        {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("die");
                alive = false;
        }

        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("idle");
                alive = true;
            }
        }
    }
}
