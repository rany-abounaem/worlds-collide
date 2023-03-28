using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Different AI scripts for each AI, and have specific checks inside it then call them in states?

public class PlateKnight : Enemy
{
    public GameObject spear;
    public GameObject shield;
    public GameObject spearPrefab;

    private void Start()
    {
        //player = null;
        //anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
        //currentState = new PlateKnightIdleState(gameObject, this, anim, player, rb);

        //PlateKnightDashingThrust action = new PlateKnightDashingThrust(gameObject, spear, shield);
        //actions.Add(action);
        //action = new PlateKnightDashingThrust(gameObject, spear, shield);
        //actions.Add(action);
        //PlateKnightThrow actionThrow = new PlateKnightThrow(gameObject, spearPrefab);
        //actions.Add(actionThrow);
    }

    private void Update()
    {
        //currentState = currentState.Process();
    }
}


//public class PlateKnightAI : MonoBehaviour
//{
//    public bool faceRight = true;
//    public enum State { IDLE, WALK, ATTACK };
//    public State state = State.WALK;
//    public Transform[] waypoints;
//    public int moveSpeed = 5;
//    Rigidbody2D rb;
//    Animator anim;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//        StartCoroutine(CheckSurrounding());

//    }


//    void Update()
//    {
//        if(state == State.WALK)
//        {
//            Walk();
//            CheckLocation();

//        }
//        //CheckSurrounding();

//    }

//    void Walk()
//    {
//        anim.SetBool("isWalking", true);
//        if (faceRight)
//        {
//            rb.velocity = new Vector2(1 * moveSpeed, rb.velocity.y);
//        }
//        else
//        {
//            rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
//        }
//    }

//    void CheckLocation()
//    {
//        if ((transform.position.x < waypoints[0].position.x && !faceRight) || transform.position.x > waypoints[1].position.x && faceRight)
//        {
//            StartCoroutine("Idle");
//        }
//    }

//    IEnumerator CheckSurrounding()
//    {
//        RaycastHit2D leftSideScan = Physics2D.Raycast(transform.position, new Vector2(-1, -1), 10f);
//        Debug.DrawRay(transform.position, new Vector2(-1, 1), Color.red, 2f);
//        if (leftSideScan)
//        {
//            if (leftSideScan.collider.CompareTag("Player"))
//            {
//                // USE ATTACK ACTION
//                state = State.ATTACK;
//                anim.SetTrigger("Attack1");
//            }
//        }
//        RaycastHit2D rightSideScan = Physics2D.Raycast(transform.position, new Vector2(1, -1), 10f);
//        if (rightSideScan)
//        {
//            if (rightSideScan.collider.CompareTag("Player"))
//            {
//                // USE ATTACK ACTION
//                state = State.ATTACK;
//                anim.SetTrigger("Attack1");
//            }
//        }
//        yield return new WaitForSeconds(1f);
//        StartCoroutine(CheckSurrounding());
//    }

//    void SwitchDirection()
//    {
//        if (faceRight)
//        {
//            faceRight = false;
//        }
//        else
//        {
//            faceRight = true;
//        }
//        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
//    }

//    IEnumerator Idle()
//    {
//        state = State.IDLE;
//        anim.SetBool("isWalking", false);
//        yield return new WaitForSeconds(3);
//        SwitchDirection();
//        state = State.WALK;
//    }

//    public void DashForce()
//    {
//        float forceValue = faceRight ? 5f : -5f;
//        rb.AddForce(new Vector2(forceValue, 0));
//    }

//    public void ResetToWalk()
//    {
//        state = State.WALK;
//        Debug.Log("State walk");
//    }



//}