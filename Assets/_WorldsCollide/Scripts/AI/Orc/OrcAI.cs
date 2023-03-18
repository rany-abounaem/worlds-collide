using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAI : AI
{
    public GameObject hammer;
    // Start is called before the first frame update
    void Start()
    {
        player = StatsComponent.instance.transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentState = new OrcIdleState(gameObject, this, anim, player, rb);

        //OrcHammerSmash orcHammerSmash = new OrcHammerSmash(gameObject, hammer);
        //actions.Add(orcHammerSmash);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}
