using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float sensitivity = 3.0f;
    public bool allowFreeLook = true;
    public bool isInverted;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
        offset = transform.position - player.position;
        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;
    }

    void LateUpdate()
    {
        FollowPlayer();
        if (allowFreeLook || Input.GetMouseButton(1))
        {
            RotateCamera();
        }
    }

    void FollowPlayer()
    {
        transform.position = player.position + offset;
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        yaw += mouseX;
        pitch -= isInverted ? -mouseY : mouseY;

        pitch = Mathf.Clamp(pitch, -30f, 60f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        offset = Quaternion.Euler(pitch, yaw, 0.0f) * new Vector3(0, 0, -offset.magnitude);
    }
}