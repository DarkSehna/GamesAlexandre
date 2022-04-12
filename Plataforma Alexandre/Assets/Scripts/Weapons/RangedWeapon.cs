using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    protected SO_RangedWeaponData rangedWeaponData;
    protected Projectile projectileScript;
    public GameObject attackPosition;
    public GameObject projectile;

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        var projectilePrefab = GameObject.Instantiate(projectile, attackPosition.transform.position, attackPosition.transform.rotation);
        projectileScript = projectilePrefab.GetComponent<Projectile>();
        projectileScript.FireProjectile(10,10,1);
    }
}
