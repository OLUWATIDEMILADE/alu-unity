using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float fallThreshold = -30f; // Height at which the player resets

    private Rigidbody rb;
    private Vector3 startPosition; // Store the initial position

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Save start position
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        // Reset player if they fall
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    private void Respawn()
    {
        Debug.Log("Player fell! Respawning...");
        transform.position = startPosition; // Reset position
        rb.velocity = Vector3.zero; // Reset momentum
    }
}
