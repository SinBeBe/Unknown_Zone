using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    private Vector3 cameraPos;

    [SerializeField]
    private float mouseSensitivity = 100f;
    private float xRotation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cameraPos = playerPos.position + new Vector3(0f, 3f, 0f);
    }

    private void Update()
    {
        RotateCamera();
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(playerPos.position.x, cameraPos.y, playerPos.position.z);
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerPos.Rotate(Vector3.up * mouseX);
    }
}
