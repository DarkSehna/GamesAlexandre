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

        var rangedWeapon = weaponData as SO_RangedWeaponData;
        float angle = Vector2.SignedAngle(Vector2.right, shotAngle);
        Vector2 spawnPosition = (mousePosition - attackPosition.transform.position).normalized * rangedWeapon.projectileSpawnRadius;
        var projectilePrefab = GameObject.Instantiate(projectile, attackPosition.transform.position, Quaternion.Euler(0f, 0f, angle));
        
        projectileScript = projectilePrefab.GetComponent<Projectile>();
        projectileScript.FireProjectile(rangedWeapon.projectileSpeed, rangedWeapon.projectileTravelDistance, rangedWeapon.projectileDamage);
        projectileScript.objectToSpawn = objectToSpawn;
    }
}
