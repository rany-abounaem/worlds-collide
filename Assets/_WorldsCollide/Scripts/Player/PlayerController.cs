using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator anim;

    public bool faceRight = true;
    bool jumpClicked, shiftClicked;

    public float moveSpeed, jumpForce, rollForce;
    float moveInput;
    float rollCooldown = 0;

    Dictionary<string, int> controllerCooldowns;

    public bool isGrounded;
    public bool isWallHanging;
    public bool isAttacking;
    public Transform leg1;
    public Transform leg2;
    public LayerMask ground;

    public int remainingJumps;

    public static PlayerController instance;

    public UnityEvent leftWeaponHit, rightWeaponHit,
        throwWeapon, rightClickPressed;

    InputActions _inputActions;

    [SerializeField] UIManager _UIManager;

    public delegate void PickupHandler(IPickupable pickupable);

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (_inputActions == null)
        {
            _inputActions = new InputActions();
            Cursor.visible = false; 
            _inputActions.Enable();
        }

        _inputActions.UI.OpenInventory.performed += _ => ToggleInventory();
        _inputActions.Game.Pickup.performed += _ => HandlePickup();

    }

    void ToggleInventory()
    {
        _UIManager.ToggleInventory();
    }

    void HandlePickup()
    {
        _UIManager.ToggleInventory();
    }

    private void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(leg1.position, checkRadius, ground) || Physics2D.OverlapCircle(leg2.position, checkRadius, ground);

        moveInput = _inputActions.Game.Movement.ReadValue<float>();
        if (moveInput != 0 && isGrounded)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);

        if (isGrounded && (moveInput > 0 || moveInput < 0)) //Increase move speed when jumping to give a feeling that it's better to bunny hop
            rb.AddForce(new Vector2(moveInput * moveSpeed, 0));
                //rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        else if (!isGrounded && (moveInput > 0 || moveInput < 0))
            rb.AddForce(new Vector2(moveInput * (moveSpeed + 2), 0));
        //rb.velocity = new Vector2(moveInput * (moveSpeed + 2), rb.velocity.y);
        if (moveInput < 0 && faceRight)
        {
            faceRight = false;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            //transform.localRotation *= Quaternion.Euler(0, 180, 0);
        }
        else if (moveInput > 0 && !faceRight)
        {
            faceRight = true;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            //transform.localRotation *= Quaternion.Euler(0, 0, 180);
        }

        if (jumpClicked)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            remainingJumps--;
            jumpClicked = false;
        }

        if (shiftClicked)
        {
            rb.AddForce(new Vector2(faceRight ? 1 : -1, 0.5f) * rollForce, ForceMode2D.Impulse);
            anim.SetTrigger("Roll");
            rollCooldown = 1;
            shiftClicked = false;
        }

    }

    void Update()
    {
        if (rollCooldown > 0)
        {
            rollCooldown -= Time.deltaTime;
        }

        if (_inputActions.Game.Jump.triggered && remainingJumps > 0)
        {
            jumpClicked = true;
        }

        if (_inputActions.Game.Roll.triggered  && rollCooldown <= 0)
        {
            shiftClicked = true;
        }


        if (_inputActions.Game.Attack_1.triggered)
        {
            isAttacking = true;
            anim.SetTrigger("Attack");
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    //isAttacking = true;
        //    anim.SetTrigger("Attack2");
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //isAttacking = true;
        //    anim.SetTrigger("Attack3");
        //}


        //if (Input.GetKey(KeyCode.W) && remainingJumps == 0 && isGrounded)
        //    rb.velocity = Vector2.up * jumpForce;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //        anim.SetBool("isJumping", false);
    //        remainingJumps = 2;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") && Vector2.Distance(collision.transform.position, transform.position) > 5)
    //    {
    //        anim.SetBool("isJumping", true);
    //        isGrounded = false;
    //    }
    //}

    public void SetAttackingBoolean(int value)
    {
        if (value == 0)
        {
            isAttacking = false;
        }
        else
            isAttacking = true;
    }

    public void InvokeLeftHit()
    {
        leftWeaponHit.Invoke();
    }

    public void InvokeRightHit()
    {
        rightWeaponHit.Invoke();
    }

    public void InvokeThrow()
    {
        throwWeapon.Invoke();
    }

    public void InvokeRightClickPressed()
    {
        rightClickPressed.Invoke();
    }

    //void AddControllerActionToCooldown(string actionName)
    //{

    //}

    //bool CheckCooldown (string actionName)
    //{

    //}

    //void UpdateCooldowns()
    //{

    //}


}
