using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AI : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;
    [field:SerializeField]
    public float Health { get; set; }
    [field: SerializeField]
    public float MaxHealth { get; set; }
    public int DamagePower { get; set; }
    public int DefensePower { get; set; }
    public List<Action> actions = new List<Action>();
    public bool faceRight = true;
    public Slider slider;

    protected Animator anim;
    protected Rigidbody2D rb;
    protected State currentState;

    public virtual bool TakeDamage(int value)
    {
        Health -= value;
        slider.value =  Health / MaxHealth;
        Debug.Log(Health);

        if (Health <= 0)
        {
            Health = 0;
            Instantiate(GameManager.instance.ExpGainEffect, transform.position, Quaternion.identity);
            return true;
        }
        else return false;
    }

    public virtual void UseAction(int index)
    {
        actions[index].UseAction();
    }


}
