using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AgressiveWeapon : Weapon
{
    protected SO_AgressiveWeaponData agressiveWeaponData;
    private List<IDamageable> detectedDamageable = new List<IDamageable>();
    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();
    protected override void Awake()
    {
        base.Awake();

        if(weaponData.GetType() == typeof(SO_AgressiveWeaponData))
        {
            agressiveWeaponData = (SO_AgressiveWeaponData)weaponData;
        }
        else
        {
            Debug.Log("wrong data from the weapon");
        }
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = agressiveWeaponData.AttackDetails[attackCounter];
        foreach (IDamageable item in detectedDamageable.ToList())
        {
            item.Damage(details.damageAmount, this.gameObject);
        }
        foreach (IKnockbackable item in detectedKnockbackables.ToList())
        {
            item.Knockback(details.knockbackAngle, details.knockbackStrength, core.Movement.facingDirection);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if(damageable != null)
        {
            detectedDamageable.Add(damageable);
        }
        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();
        if (knockbackable != null)
        {
            detectedKnockbackables.Add(knockbackable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            detectedDamageable.Remove(damageable);
        }
        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();
        if (knockbackable != null)
        {
            detectedKnockbackables.Remove(knockbackable);
        }
    }
}
