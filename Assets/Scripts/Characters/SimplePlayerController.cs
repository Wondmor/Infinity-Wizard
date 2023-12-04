using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public float movePower = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    private int direction = 1;
    private bool alive = true;

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
            Move();
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveVelocity = new Vector3(horizontalInput, verticalInput, 0).normalized;
        anim.SetBool("isRun", false);

        if (moveVelocity != Vector3.zero)
        {
            anim.SetBool("isRun", true);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;

        // Flip the character based on movement direction
        if (horizontalInput < 0)
        {
            direction = -1;
        }
        else if (horizontalInput > 0)
        {
            direction = 1;
        }

        transform.localScale = new Vector3(direction, 1, 1) * 0.35f;
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
        anim.SetTrigger("die");
        alive = false;
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            anim.SetTrigger("idle");
            alive = true;
        }
    }
}