using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerController : MonoBehaviour, IMoveObject
{
    private ItemData data;

    [SerializeField]
    private AudioSource moveAudio;
    [SerializeField]
    private GameObject flashLight;
    [SerializeField]
    private Transform rayPos;

    private Rigidbody rb;

    private RaycastHit hit;

    private LayerMask masks;
    private LayerMask item;
    private LayerMask hideObj;
    private LayerMask skill;

    private float walkSpeed = 7f;
    private float runSpeed = 13f;

    private Vector3 direction { get; set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        masks = (1 << 6) | (1 << 8);
        item = (1 << 6);
        hideObj = (1 << 8);
        skill = (1 << 9);
    }

    private void Update()
    {
        Interact();
    }

    private void FixedUpdate()
    {
        bool isRun = Input.GetKey(KeyCode.LeftShift) ? true : false;
        if (isRun)
        {
            Move(runSpeed);
        }
        else
        {
            Move(walkSpeed);
        }
    }

    public void Move(float speed)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.z); 
        moveDirection = transform.TransformDirection(moveDirection);

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z) * speed;
    }

    private void Interact()
    {
        Debug.DrawRay(rayPos.position, transform.forward * 8f, Color.red);
        if (Physics.Raycast(rayPos.position, transform.forward, out hit, 8f, masks))
        {
            UIManager.instance.ImageOnOff(UIManager.instance.interactImage, true);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                LayerMask hitObjLayer = hit.collider.gameObject.layer;
                if (hitObjLayer == item)
                {
                    data = hit.collider.gameObject.GetComponent<ItemData>();
                    data.Count += 1;
                    data.IsGet = true;

                    Destroy(hit.collider.gameObject);
                    //아이템 먹는 소리
                }
                else if (hitObjLayer == skill)
                {
                    //skill 로직
                }
                else if (hitObjLayer == hideObj)
                {
                    //hide 로직
                }
            }
        }
        else
        {
            UIManager.instance.ImageOnOff(UIManager.instance.interactImage, false);
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        direction = new Vector3(input.x, 0f, input.y);
    }
    
    public void OnOffFlashLight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            flashLight.SetActive(!flashLight.activeSelf);
        }
    }
}
