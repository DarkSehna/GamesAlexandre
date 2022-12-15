using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Flee State Data", menuName = "Data / State Data / Flee State")]
public class D_FleeState : ScriptableObject
{
    public GameObject objectToSpawn;
    public float fleeSpeed = 6f;
    public float fleeTime = 2f;
    public bool fleeForever;
}
