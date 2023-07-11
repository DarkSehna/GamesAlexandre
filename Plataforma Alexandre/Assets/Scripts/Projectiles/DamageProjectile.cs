using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProjectile : Projectile
{
    [SerializeField] int damage = 10;
    private Player player;


    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.transform.tag == "Player")
        {
            IDamageable damageable = collision.transform.GetComponentInChildren<IDamageable>();
            if (damageable != null)
            {
                DamageEntity(damageable, damage);
                Debug.Log("damage");
            }

            IKnockbackable knockbackable = collision.transform.GetComponentInChildren<IKnockbackable>();
            if (knockbackable != null)
            {
                player = collision.transform.GetComponent<Player>();
                KnockbackEntity(knockbackable, player.Core.Movement.facingDirection);
                Debug.Log("knockback");
            }
        }
        Destroy(gameObject);
    }

    public void DamageEntity(IDamageable entity, float damage)
    {
        entity.Damage(damage, this.gameObject);
    }

    public void KnockbackEntity(IKnockbackable entity, int facingDirection)
    {
        entity.Knockback(Vector2.one, 10f, -facingDirection);
    }
}
