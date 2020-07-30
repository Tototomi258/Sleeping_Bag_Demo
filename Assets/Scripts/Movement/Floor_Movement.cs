using UnityEngine;

public class Floor_Movement : MonoBehaviour
{
    public float speed = 1f;
    public float target;
    public Rigidbody2D rb;
    public bool move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (move)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                target -= 2;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                target += 2;
            }
        }
        else
        {
            target = rb.rotation;
        }
    }

    private void FixedUpdate()
    {
        if (move)
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, target, speed * Time.deltaTime));
        }
    }
}
