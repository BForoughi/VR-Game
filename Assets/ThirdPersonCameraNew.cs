using UnityEngine;

public class ThirdPersonCameraNew : MonoBehaviour
{
    public Transform target;
    public RobotControllerTwo robot;
    public float mouseSensitivity = 3f;
    public float distance = 5f;
    public float height = 2f;

    public float smoothSpeed = 10f;
    public float rotationSmooth = 12f;

    float yaw;
    float pitch = 15f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {

        if (!target) return;

        // Mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;

        pitch = Mathf.Clamp(pitch, -30f, 60f);

        // Desired rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Desired camera position
        Vector3 desiredPosition =
            target.position
            + Vector3.up * height
            - rotation * Vector3.forward * distance;

        // Smooth movement
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // Smooth rotation
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            rotation,
            rotationSmooth * Time.deltaTime
        );
    }

}