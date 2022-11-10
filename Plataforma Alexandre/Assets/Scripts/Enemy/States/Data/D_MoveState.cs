using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Move State Data",menuName ="Data / State Data / Move State")]
public class D_MoveState : ScriptableObject
{
    public float movementSpeed = 3f;
    public float jumpTime = 0.2f;
    public Vector2 jumpAngle;

    [Header("Movement Damage")]
    public float hitRadius = 0.5f;
    public float hitDamage = 10f;
    public LayerMask whatIsPlayer;
    public Vector2 knockbackAngle = Vector2.one;
    public float knockbackStrength = 10f;
}
