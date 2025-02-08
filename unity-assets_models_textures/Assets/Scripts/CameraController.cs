using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Assign the player in the Inspector
    public Vector3 offset = new Vector3(0, 3, -6); // Camera position offset
    public float smoothSpeed = 5f; // How smoothly the camera follows the player

    public float mouseSensitivity = 2.0f; // Mouse sensitivity for rotation
    private float rotationX = 0f;
    private float rotationY = 0f;
    private bool isRightClickHeld = false;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("CameraController: No GameObject with tag 'Player' found!");
                return;
            }
        }

        // Initialize camera rotation
        Vector3 angles = transform.eulerAngles;
        rotationX = angles.x;
        rotationY = angles.y;
    }

    void Update()
    {
        // Check if right mouse button is held for rotation control
        isRightClickHeld = Input.GetMouseButton(1);

        if (isRightClickHeld)
        {
            RotateCamera();
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -30f, 60f); // Limit vertical rotation

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
