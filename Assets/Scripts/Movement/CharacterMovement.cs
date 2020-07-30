using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public bool move;
    public float gravity;

    private Vector2 direction = new Vector2(0, 0);
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<GameManager>().PauseGame();
        }

        if (move)
        {
            rb.gravityScale = 0f;
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        else
        {
            rb.gravityScale = gravity;
        }
    }

    private void FixedUpdate()
    {
        if (move)
        {
            rb.AddForce(direction * speed);

            if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
            }

            if (Mathf.Abs(rb.velocity.y) > maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * maxSpeed);
            }
        }
    }
}
