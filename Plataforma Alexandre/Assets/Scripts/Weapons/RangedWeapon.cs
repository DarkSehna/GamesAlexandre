using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    protected Projectile projectileScript;
    public GameObject attackPosition;
    public GameObject projectile;

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        var projectilePrefab = GameObject.Instantiate(projectile, attackPosition.transform.position, attackPosition.transform.rotation);
        projectileScript = projectilePrefab.GetComponent<Projectile>();
        var rangedWeapon = weaponData as SO_RangedWeaponData;
        projectileScript.FireProjectile(rangedWeapon.projectileSpeed, rangedWeapon.projectileTravelDistance, rangedWeapon.projectileDamage);
        projectileScript.objectToSpawn = objectToSpawn;
    }
}
