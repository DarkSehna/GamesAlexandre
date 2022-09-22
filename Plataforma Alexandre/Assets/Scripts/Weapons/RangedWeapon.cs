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
        Vector2 spawnPosition = (mousePosition - attackPosition.transform.position).normalized * rangedWeapon.projectileSpawnRadius;
        float angle = Vector2.SignedAngle(Vector2.right, spawnPosition);
        Debug.DrawLine(attackPosition.transform.position, (Vector2)attackPosition.transform.position + spawnPosition, Color.red, 1f);
        var projectilePrefab = GameObject.Instantiate(projectile, (Vector2)attackPosition.transform.position + spawnPosition, Quaternion.Euler(0f, 0f, angle));
        
        projectileScript = projectilePrefab.GetComponent<Projectile>();
        projectileScript.FireProjectile(rangedWeapon.projectileSpeed, rangedWeapon.projectileTravelDistance, rangedWeapon.projectileDamage);
        projectileScript.objectToSpawn = objectToSpawn;
    }
}
