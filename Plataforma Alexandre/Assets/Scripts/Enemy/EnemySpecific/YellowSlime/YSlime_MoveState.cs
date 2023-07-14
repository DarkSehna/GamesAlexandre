using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSlime_MoveState : MoveState
{
    private YellowSlime enemy;
    protected Transform hitPosition;
    private bool canDamage;
    public YSlime_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, YellowSlime enemy, Transform hitPosition) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
        this.hitPosition = hitPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        //base.Enter();
        canDamage = true;
        startTime = Time.time;

        core.Movement.SetVelocity(stateData.movementSpeed, stateData.jumpAngle, core.Movement.facingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        //base.LogicUpdate();

        if(canDamage)
        {
            DamagePlayer();
        }

        if (Time.time >= startTime + stateData.jumpTime && isTouchingGround)
        {
            //enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void DamagePlayer()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(hitPosition.position, stateData.hitRadius, stateData.whatIsPlayer);
        foreach (Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponentInChildren<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(stateData.hitDamage, entity.gameObject);
                canDamage = false;
            }

            IKnockbackable knockbackable = collider.GetComponentInChildren<IKnockbackable>();
            if (knockbackable != null)
            {
                knockbackable.Knockback(stateData.knockbackAngle, stateData.knockbackStrength, core.Movement.facingDirection);
            }
        }
    }
}
