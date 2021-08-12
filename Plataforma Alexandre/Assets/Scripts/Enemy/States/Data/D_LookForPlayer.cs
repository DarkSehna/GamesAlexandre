using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Look For Player State Data", menuName = "Data / State Data / Look For Player State")]
public class D_LookForPlayer : ScriptableObject
{
    public int amountOfTurns = 2;
    public float timeBetweenTurns = 0.75f;
}
