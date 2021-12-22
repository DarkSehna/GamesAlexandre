using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Weapon Data", menuName = "Data/Weapon Data/Ranged Weapon")]
public class SO_RangedWeaponData : SO_WeaponData
{
    public GameObject projectile;

    public float projectileDamage = 10f;
    public float projectileSpeed = 12f;
    public float projectileTravelDistance = 5f;
}
