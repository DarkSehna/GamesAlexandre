using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTackleState : PlayerAbilityState
{
    private bool isTackleTimeOver;
    private bool canDamage;
    private Collider2D enemyDetected;

    public PlayerTackleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        isTackleTimeOver = false;
        canDamage = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityX(playerData.tackleSpeed * core.Movement.facingDirection);
        enemyDetected = Physics2D.OverlapCircle(player.tackleAttackPosition.position, playerData.tackleCollisionRadius, playerData.whatIsEnemy);

        if (Time.time > startTime + playerData.tackleTime)
        {
            isTackleTimeOver = true;
        }

        if (enemyDetected)
        {
            if (canDamage)
            {
                TriggerAttack();
                canDamage = false;
            }
        }

        if(isTackleTimeOver)
        {
            isAbilityDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void TriggerAttack()
    {
        {
            IDamageable damageable = enemyDetected.GetComponentInChildren<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(playerData.tackleDamage, player.gameObject);
            }

            IKnockbackable knockbackable = enemyDetected.GetComponentInChildren<IKnockbackable>();
            if (knockbackable != null)
            {
                knockbackable.Knockback(playerData.tackleKnockbackAngle, playerData.tackleKnockbackPower, core.Movement.facingDirection);
            }
        }
    }
}
