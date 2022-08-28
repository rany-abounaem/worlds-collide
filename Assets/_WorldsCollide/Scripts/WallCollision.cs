using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Collision Enter");
            PlayerController.instance.isWallHanging = true;
            PlayerController.instance.anim.SetBool("isWallHanging", true);
            PlayerController.instance.remainingJumps = 2;
            rb.gravityScale -= 1;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Collision Exit");
            PlayerController.instance.isWallHanging = false;
            PlayerController.instance.anim.SetBool("isWallHanging", false);
            rb.gravityScale += 1;
        }
    }
}
