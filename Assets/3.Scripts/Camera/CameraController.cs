using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Transform rayPos;
    private Vector3 cameraPos;

    private RaycastHit hit;
    private LayerMask masks;

    [SerializeField]
    private float mouseSensitivity = 100f;
    private float xRotation = 0;

    private void Start()
    {
        masks = (1 << 6) | (1 << 7) | (1 << 8);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cameraPos = playerPos.position + new Vector3(0f, 3f, 0f);
    }

    private void Update()
    {
        RotateCamera();
        Interact();
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

    private void Interact()
    {
        Debug.DrawRay(rayPos.position, transform.forward * 8f, Color.red);
        if(Physics.Raycast(rayPos.position, transform.forward, out hit, 8f, masks))
        {
            UIManager.instance.ImageOnOff(UIManager.instance.interactImage, true);
        }
        else
            UIManager.instance.ImageOnOff(UIManager.instance.interactImage, false);
    }
}
