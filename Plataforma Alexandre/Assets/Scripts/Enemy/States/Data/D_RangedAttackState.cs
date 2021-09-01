using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Attack State Data", menuName = "Data / State Data / Ranged Attack State")]
public class D_RangedAttackState : ScriptableObject
{
    public GameObject projectile;

    public float projectileDamage = 10f;
    public float projectileSpeed = 12f;
    public float projectileTravelDistance = 5f;
}
