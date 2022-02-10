using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int DamagePower { get; set; }
    public int DefensePower { get; set; }
    public List<Action> actions = new List<Action>();
    public bool faceRight = true;

    protected Animator anim;
    protected Rigidbody2D rb;
    protected State currentState;

    public bool TakeDamage(int value)
    {
        Health -= value;
        Debug.Log(Health);

        if (Health <= 0)
        {
            Health = 0;
            Instantiate(GameManager.instance.ExpGainEffect, transform.position, Quaternion.identity);
            return true;
        }
        else return false;
    }

    public void UseAction(int index)
    {
        actions[index].UseAction();
    }


}
