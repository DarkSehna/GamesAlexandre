using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] int damage = 99;
    
    public void DamageEntity(IDamageable entity, float damage)
    {
        entity.Damage(damage);
    }

    public void KnockbackEntity(IKnockbackable entity)
    {
        entity.Knockback(Vector2.one, 10f, -1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerStay2D(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if(damageable != null)
        {
            DamageEntity(damageable, damage);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();
        if(knockbackable != null && gameObject.tag != "Water")
        {
            KnockbackEntity(knockbackable);
        }
    }
}
