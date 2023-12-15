using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerExplosionState : PlayerAbilityState
{
    private bool isExplosionTimeOver;
    private bool enemyHit;
    private bool canDamage;
    private Collider2D enemyDetected;
    private List<IDamageable> detectedDamageable = new List<IDamageable>();
    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();
    private int knockbackDirection;

    public PlayerExplosionState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        TriggerAttack();
    }



    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        isExplosionTimeOver = false;
        enemyHit = false;
        canDamage = true;
    }

    public override void Exit()
    {
        base.Exit();

        detectedDamageable.Clear();
        detectedKnockbackables.Clear();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemyDetected = Physics2D.OverlapCircle(player.explosionAttackPosition.position, playerData.explosionCollisionRadius, playerData.whatIsEnemy);
        if(enemyDetected)
        {
            AddToDetected(enemyDetected);
        }
        
        
        core.Movement.SetVelocityX(0f);

        if (Time.time > startTime + playerData.explosionTime)
        {
            isExplosionTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void TriggerAttack()
    {
        
            //IDamageable damageable = enemyDetected.GetComponentInChildren<IDamageable>();
            //if (damageable != null)
            //{
            //    damageable.Damage(playerData.explosionDamage, player.gameObject);
            //}

            //IKnockbackable knockbackable = enemyDetected.GetComponentInChildren<IKnockbackable>();
            //if (knockbackable != null)
            //{
            //    knockbackable.Knockback(playerData.explosionKnockbackAngle, playerData.explosionKnockbackPower, knockbackDirection);
            //}

            foreach (IDamageable item in detectedDamageable.ToList())
            {
                item.Damage(playerData.explosionDamage, player.gameObject);
            }
            foreach (IKnockbackable item in detectedKnockbackables.ToList())
            {
                SetKnockbackDirection();
                item.Knockback(playerData.explosionKnockbackAngle, playerData.explosionKnockbackPower, knockbackDirection);
            }
        
    }

    public void AddToDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
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

    public void SetKnockbackDirection()
    {
        var playerPosition = player.transform.position.x;
        var enemyPosition = enemyDetected.GetComponent<Transform>().position.x;

        if (enemyPosition > playerPosition)
        {
            knockbackDirection = 1;
        }
        else
        {
            knockbackDirection = -1;
        }
    }
}
