using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
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
        if(Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, 2f, masks))
        {
            UIManager.instance.ImageOnOff(UIManager.instance.interactImage, true);
        }
        else
        {
            UIManager.instance.ImageOnOff(UIManager.instance.interactImage, false);
        }
    }
}
