using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Charge State Data", menuName = "Data / State Data / Charge State")]
public class D_ChargeState : ScriptableObject
{
    public float chargeSpeed = 6f;
    public float chargeTime = 2f;

    public float collisionRadius;
    public LayerMask whatIsPlayer;
}
