using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer; // For å sjekke bakken

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

 void Update()
{
    // Horisontal bevegelse (A/D eller piltaster)
    float moveX = Input.GetAxis("Horizontal");
    rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

    // Hopp
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    // Sjekk om på bakken
    CheckIfGrounded();
}

    void CheckIfGrounded()
    {
        // Sjekk med en liten boks under figuren
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.1f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        isGrounded = hit.collider != null;
    }
}