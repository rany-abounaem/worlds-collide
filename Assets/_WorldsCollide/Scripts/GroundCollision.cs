using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider);
        //Debug.Log(collision.otherCollider);
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerController.instance.isGrounded = true;
            PlayerController.instance.anim.SetBool("isJumping", false);
            PlayerController.instance.remainingJumps = 2;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerController.instance.anim.SetBool("isJumping", true);
            PlayerController.instance.isGrounded = false;
        }
    }
}
