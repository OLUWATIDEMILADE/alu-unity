using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float fallThreshold = -30f;

    private Rigidbody rb;
    private Animator animator;
    private Vector3 startPosition;

    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    private void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        bool isMoving = moveDirection.magnitude > 0.1f;
        animator.SetBool("isMoving", isMoving);

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Jump
        isGrounded = IsGrounded();
        animator.SetBool("isGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            animator.SetTrigger("jump");
        }

        // Reset if player falls
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
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
    }
}
