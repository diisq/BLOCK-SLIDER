using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 100f; // Mouse sensitivity
    private float xRotation = 0f;
    private float yRotation = 0f;
    public Transform ori;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevents flipping the camera

        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        ori.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
