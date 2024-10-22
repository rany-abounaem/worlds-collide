//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlateKnightPatrolState : State
//{
//    float moveSpeed = 7;
//    Transform[] waypoints;
    

//    public PlateKnightPatrolState (GameObject _npc, AI _ai, Animator _anim, Transform _player, Rigidbody2D _rb) : base(_npc, _ai, _anim, _player, _rb)
//    {
//        name = STATE.PATROL;
//        waypoints = ai.waypoints;
//    }

//    public override void Enter()
//    {
//        anim.SetBool("isWalking", true);
//        Debug.Log("Walk set");
//        base.Enter();
//    }

//    public override void Update()
//    {
//        Walk();
//        CheckLocation();
//        CheckSurrounding();
//    }

//    public override void Exit()
//    {
//        rb.velocity = new Vector2(0, 0);
//        anim.SetBool("isWalking", false);
//        //anim.ResetTrigger("isWalking");
//        Debug.Log("Walk unset");
//        base.Exit();
//    }

//    void Walk()
//    {
//        int factor = npc.transform.localScale.x > 0 ? 1 : -1;
//        rb.velocity = new Vector2(factor * moveSpeed, rb.velocity.y);
//    }

//    void CheckLocation()
//    {
//        if ((npc.transform.position.x < waypoints[0].position.x && npc.transform.localScale.x < 0) ||
//            npc.transform.position.x > waypoints[1].position.x && npc.transform.localScale.x > 0)
//        {
            
//            npc.transform.localScale = new Vector2(-npc.transform.localScale.x, npc.transform.localScale.y);
//            nextState = new PlateKnightIdleState(npc, ai, anim, player, rb);
//            stage = EVENT.EXIT;
//        }
//    }

//    void CheckSurrounding()
//    {
//        float distance = Vector2.Distance(npc.transform.position, player.position);
//        float scaleX = npc.transform.localScale.x;
//        if (distance <= 8f && distance >= 1.4f)
//        {
//            // Chance to aggro
//            int chance = Random.Range(0, 1000);
//            if (chance < 10)
//            {
//                if ((scaleX > 0 && npc.transform.position.x > player.position.x) || (scaleX < 0 && npc.transform.position.x < player.position.x))
//                    npc.transform.localScale = new Vector2(-scaleX, npc.transform.localScale.y);
//                nextState = new PlateKnightThrowState(npc, ai, anim, player, rb);
//                stage = EVENT.EXIT;
//            }
            
//        }
//    }
//}
