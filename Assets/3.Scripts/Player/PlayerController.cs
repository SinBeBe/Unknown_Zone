using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : ManagerBase, IMoveObject
{
    [SerializeField]
    private AudioSource moveAudio;
    [SerializeField]
    private GameObject flashLight;
    [SerializeField]
    private Transform rayPos;

    private Rigidbody rb;
    private Collider col;

    private Item item;

    private RaycastHit hit;
    private RaycastHit[] hits;

    private LayerMask masks;
    private LayerMask itemLayer = (1 << 6);
    private LayerMask hideObj = (1 << 8);

    private bool isInteract;
    private bool isMove;

    private Vector3 direction { get; set; }

    private Vector3 originPos;

    private float hp;

    private void Start()
    {
        FindManager();

        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        hp = gi.playerData.HP;

        masks = (1 << 6) | (1 << 8);
    }

    private void Update()
    {
        Interact();

        bool isRun = Input.GetKey(KeyCode.LeftShift) ? true : false;
        if (!gi.isPlayerLimit)
        {
            ui.PlayerStaminaUpdate(isRun);
            if (isMove)
            {
                if (isRun && !gi.isExhausted)
                {
                    Move(gi.playerSpeed * 2, 1);
                }
                else
                {
                    Move(gi.playerSpeed, 0);
                }
            }
            else
            {
                moveAudio.Stop();
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void Move(float speed, int index)
    {
        if (!gi.isPlayerHide)
        {
            if (!moveAudio.isPlaying || moveAudio.clip != ai.playerMoveClip[index])
            {
                ai.PlayAudiocilp(moveAudio, ai.playerMoveClip[index], true);
            }
            Vector3 moveDirection = new Vector3(direction.x, 0f, direction.z); 
            moveDirection = transform.TransformDirection(moveDirection);

            rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z) * speed;
        }
        else
        {
            moveAudio.Stop();
        }
    }

    private void Interact()
    {
        Debug.DrawRay(rayPos.position, rayPos.forward * 8f, Color.red);
        hits = Physics.RaycastAll(rayPos.position, rayPos.forward, 8f, masks);
        if (hits.Length > 0 || gi.isPlayerHide)
        {
            isInteract = true;
            foreach (RaycastHit hit in hits)
            {
                this.hit = hit;
            }
        }
        else
        {
            isInteract = false;
        }
        ui.ImageOnOff(UIManager.instance.interactImage, isInteract);
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        isMove = context.performed;
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

    public void OnMouseInput(InputAction.CallbackContext context)
    {
        if (isInteract && context.performed)
        {
            LayerMask hitObjLayer = (1 << hit.collider.gameObject.layer);
            if (hitObjLayer == itemLayer)
            {
                if (hit.collider.CompareTag("UsingItem"))
                {
                    item = hit.collider.gameObject.GetComponent<Item>();
                    item.Count++;
                    item.IsGet = true;
                    Debug.Log("get item");

                    ui.ItemCount(item.data.Index, item.Count);
                    hit.collider.gameObject.transform.Translate(0f, -30f, 0f);
                    gi.items[item.data.Index] = hit.collider.gameObject;
                }
                else if(hit.collider.CompareTag("Getting"))
                {
                    if(hit.collider.gameObject.layer == LayerMask.GetMask("Map"))
                    {
                        gi.isFindKnife = true;
                    }
                    else
                    {
                        gi.OnCandle();
                        Destroy(hit.collider.gameObject);
                    }
                }
                else
                {
                    Destroy(hit.collider.gameObject);
                }
            }
            else if (hitObjLayer == hideObj && !gi.isPlayerHide)
            {
                moveAudio.clip = null;
                moveAudio.Stop();

                col.enabled = false;
                isMove = false;
                gi.isPlayerLimit = true;

                Vector3 pos = hit.transform.position;
                Quaternion rot = hit.transform.rotation;

                ai.PlayAudiocilp(ai.SFX, ai.playerHideClip[0], false);

                originPos = transform.position;

                rb.velocity = Vector3.zero;

                transform.position = new Vector3(pos.x, pos.y + 3f, pos.z);
                transform.rotation = rot;

                gi.isPlayerHide = true;
                ui.ImageOnOff(ui.hideImage, true);
            }
            else if (gi.isPlayerHide)
            {
                ai.PlayAudiocilp(ai.SFX, ai.playerHideClip[1], false);

                transform.position = originPos;

                col.enabled = true;
                isMove = true;
                gi.isPlayerLimit = false;

                gi.isPlayerHide = false;
                ui.ImageOnOff(ui.hideImage, false);
            }
        }
    }

    private void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gi.GameOver();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.collider.gameObject.layer == 7)
            {
                Die();
            }
            else
            {
                TakeDamage(30f * gi.damagePercent);
                ui.PlayerHpTextUpdate(hp);
            }
            Destroy(collision.gameObject);
        }
    }
}
