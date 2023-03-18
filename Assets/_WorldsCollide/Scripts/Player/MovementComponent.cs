using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using WorldsCollide.Input;

public class MovementComponent : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _anim;

    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _rollForce;

    private float _movementInput;
    private bool _facingRight;
    private bool _jumpPressed;
    private int _remainingJumps;
    private bool _rollPressed;

    public bool IsGrounded { get; private set; }
    

    public static MovementComponent instance;

    public UnityEvent leftWeaponHit, rightWeaponHit,
        throwWeapon, rightClickPressed;

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

    public void Setup(Animator anim, Rigidbody2D rigidbody)
    {
        _facingRight = true;
        _rigidbody = rigidbody;
        _anim = anim;
    }

    public void SetMovement(float movementInput)
    {
        _movementInput = movementInput;
    }

    public void Jump()
    {
        if (_remainingJumps > 0)
        {
            _jumpPressed = true;
        }
    }

    public void Roll()
    {
        _rollPressed = true;
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
    }


    private void FixedUpdate()
    {
        if (_movementInput != 0 && IsGrounded)
            _anim.SetBool("isMoving", true);
        else
            _anim.SetBool("isMoving", false);

        _rigidbody.AddForce(new Vector2(_movementInput * _movementSpeed, 0));

        if (_movementInput < 0 && _facingRight)
        {
            _facingRight = false;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        else if (_movementInput > 0 && !_facingRight)
        {
            _facingRight = true;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        if (_jumpPressed)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _remainingJumps--;
            _jumpPressed = false;
        }

        if (_rollPressed)
        {
            _rigidbody.AddForce(new Vector2(_facingRight ? 1 : -1, 0.5f) * _rollForce, ForceMode2D.Impulse);
            _anim.SetTrigger("Roll");
            _rollPressed = false;
        }

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
            _anim.SetBool("isJumping", false);
            _remainingJumps = 2;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            _anim.SetBool("isWallHanging", true);
            _remainingJumps = 2;
            _rigidbody.gravityScale -= 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _anim.SetBool("isJumping", true);
            IsGrounded = false;
        } 
        else if (collision.gameObject.CompareTag("Wall"))
        {
            _anim.SetBool("isWallHanging", false);
            _rigidbody.gravityScale += 1;
        }
    }
}
