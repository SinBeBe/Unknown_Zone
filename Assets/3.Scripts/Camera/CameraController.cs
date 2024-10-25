using UnityEngine;
using UnityEngineInternal;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Transform rayPos;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip clip;

    private Vector3 cameraPos;

    private RaycastHit hit;
    private LayerMask masks;
    private LayerMask item;
    private LayerMask hideObj;

    [SerializeField]
    private float mouseSensitivity = 100f;
    private float xRotation = 0;

    private void Start()
    {
        masks = (1 << 6) | (1 << 8);
        item = (1 << 6);
        hideObj = (1 << 8);

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
        if (Physics.Raycast(rayPos.position, transform.forward, out hit, 8f, masks))
        {
            UIManager.instance.ImageOnOff(UIManager.instance.interactImage, true);
            if (hit.collider.gameObject.layer == item)
            {
                Destroy(hit.collider.gameObject);
                //아이템 먹는 소리

            }
        }
        else
        {
            UIManager.instance.ImageOnOff(UIManager.instance.interactImage, false);
        }
    }
}
