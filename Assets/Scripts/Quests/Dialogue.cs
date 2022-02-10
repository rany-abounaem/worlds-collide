using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Dialogue
{
    public string dialogue, accept, reject;
    public bool acceptEnabled, rejectEnabled;
}
