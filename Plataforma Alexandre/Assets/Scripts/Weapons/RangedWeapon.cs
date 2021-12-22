using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    protected SO_RangedWeaponData rangedWeaponData;
    protected Projectile projectileScript;
    public GameObject attackPosition;

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        rangedWeaponData.projectile = GameObject.Instantiate(rangedWeaponData.projectile, attackPosition.transform.position, attackPosition.transform.rotation);
        projectileScript = rangedWeaponData.projectile.GetComponent<Projectile>();
        projectileScript.FireProjectile(rangedWeaponData.projectileSpeed, rangedWeaponData.projectileTravelDistance, rangedWeaponData.projectileDamage);
    }
}
