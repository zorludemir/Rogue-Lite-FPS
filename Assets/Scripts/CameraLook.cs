using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        ChangeCursorLockState(true);
        playerBody = transform.parent;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    public static void ChangeCursorLockState(bool islocked)
    {
        if (islocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
