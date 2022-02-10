using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAI : AI
{
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerStats.instance.transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentState = new OrcIdleState(gameObject, this, anim, player, rb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
