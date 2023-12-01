using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosionState : PlayerAbilityState
{
    private bool isExplosionTimeOver;
    private bool enemyHit;
    private bool canDamage;
    private Collider2D enemyDetected;

    public PlayerExplosionState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        isExplosionTimeOver = false;
        enemyHit = false;
        canDamage = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemyDetected = Physics2D.OverlapCircle(player.explosionAttackPosition.position, playerData.explosionCollisionRadius, playerData.whatIsEnemy);

        if (Time.time > startTime + playerData.explosionTime)
        {
            isExplosionTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
