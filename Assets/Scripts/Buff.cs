using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Buff
{
    public string name { get; set; }
    public int value { get; set; }

    public Buff(string name, int value)
    {
        this.name = name;
        this.value = value;
    }
}
