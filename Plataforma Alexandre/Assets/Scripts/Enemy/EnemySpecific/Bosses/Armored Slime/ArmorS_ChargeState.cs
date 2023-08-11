using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorS_ChargeState : ChargeState
{
    private ArmoredSlime boss;
    
    private bool playerHit;
    private bool canDamage;
    private Collider2D playerDetected;

    public ArmorS_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, ArmoredSlime boss) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.boss = boss;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        playerHit = false;
        canDamage = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        playerDetected = Physics2D.OverlapCircle(boss.meleeAttackPosition.position, stateData.collisionRadius, stateData.whatIsPlayer);

        if (playerDetected)
        {
            playerHit = true;

            if(canDamage)
            {
                TriggerAttack();
                canDamage = false;
            }
        }

        if (isDetecteingWall)
        {
            if(playerHit)
            {
                core.Movement.Flip();
                stateMachine.ChangeState(boss.idleState);
            }
            else
            {
                SelfDamage();
                stateMachine.ChangeState(boss.hitState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void TriggerAttack()
    {
        {
            IDamageable damageable = playerDetected.GetComponentInChildren<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(stateData.chargeDamage, entity.gameObject);
            }

            IKnockbackable knockbackable = playerDetected.GetComponentInChildren<IKnockbackable>();
            if (knockbackable != null)
            {
                knockbackable.Knockback(stateData.chargeKnockbackAngle, stateData.chargeKnockbackPower, core.Movement.facingDirection);
            }
        }
    }

    public void SelfDamage()
    {
        IDamageable damageable = boss.gameObject.GetComponentInChildren<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(stateData.chargeDamage, entity.gameObject);
        }
    }
}
