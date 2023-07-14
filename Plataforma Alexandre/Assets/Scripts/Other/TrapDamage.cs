using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [SerializeField] int damage = 99;

    private Player player;
    
    public void DamageEntity(IDamageable entity, float damage)
    {
        entity.Damage(damage, this.gameObject);
    }

    public void KnockbackEntity(IKnockbackable entity, int facingDirection)
    {
        entity.Knockback(Vector2.one, 10f, -facingDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OnTriggerStay2D(collision);
        }
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
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            //Debug.Log(player);
            KnockbackEntity(knockbackable, player.Core.Movement.facingDirection);
        }
    }
}
