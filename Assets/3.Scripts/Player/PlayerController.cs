using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IMoveObject
{
    private const float CONVERT_UNIT_VALUE = 0.01f;

    private Rigidbody rb;

    [SerializeField]
    private float walkSpeed = 3f;
    [SerializeField]
    private float runSpeed = 5f;

    private Vector3 direction { get; set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        Move(currentSpeed);
    }

    public void Move(float speed)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.z); 
        moveDirection = transform.TransformDirection(moveDirection);

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z) * speed;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        direction = new Vector3(input.x, 0f, input.y);
    }
    
}
