using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSlime_ChargeState : ChargeState
{
    private RedSlime enemy;

    private bool playerHit;
    private bool canDamage;
    private Collider2D playerDetected;

    public RSlime_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, RedSlime enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
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

        playerDetected = Physics2D.OverlapCircle(enemy.meleeAttackPosition.position, stateData.collisionRadius, stateData.whatIsPlayer);

        if (playerDetected)
        {
            playerHit = true;

            if (canDamage)
            {
                TriggerAttack();
                canDamage = false;

                stateMachine.ChangeState(enemy.stunState);
            }
        }
        else if (!isDetectingLedge || isDetecteingWall)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
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
        SelfKnockBack();
    }

    public void SelfKnockBack()
    {
        IKnockbackable knockbackable = enemy.gameObject.GetComponentInChildren<IKnockbackable>();
        if (knockbackable != null)
        {
            knockbackable.Knockback(stateData.chargeKnockbackAngle, stateData.chargeKnockbackPower/2, -core.Movement.facingDirection);
        }
    }
}
