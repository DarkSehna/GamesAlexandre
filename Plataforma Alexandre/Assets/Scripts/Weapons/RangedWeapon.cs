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

        float angle = Vector2.SignedAngle(Vector2.right, shotAngle);
        var projectilePrefab = GameObject.Instantiate(projectile, attackPosition.transform.position, Quaternion.Euler(0f, 0f, angle));
        projectileScript = projectilePrefab.GetComponent<Projectile>();
        var rangedWeapon = weaponData as SO_RangedWeaponData;
        projectileScript.FireProjectile(rangedWeapon.projectileSpeed, rangedWeapon.projectileTravelDistance, rangedWeapon.projectileDamage);
        projectileScript.objectToSpawn = objectToSpawn;
    }
}
