using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed
    public float jumpForce = 7.0f; // Jump force
    private Rigidbody rb; // Rigidbody for physics

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ += 1f; // Move forward
        if (Input.GetKey(KeyCode.S)) moveZ -= 1f; // Move backward
        if (Input.GetKey(KeyCode.A)) moveX -= 1f; // Move left
        if (Input.GetKey(KeyCode.D)) moveX += 1f; // Move right

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
