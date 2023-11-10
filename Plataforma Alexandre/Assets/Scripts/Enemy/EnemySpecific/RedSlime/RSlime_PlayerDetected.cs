using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSlime_PlayerDetected : PlayerDetectedState
{
    private RedSlime enemy;

    public RSlime_PlayerDetected(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, RedSlime enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction || performLongRangeAction)
        {
            stateMachine.ChangeState(enemy.chargeState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if (!isDetectingLedge)
        {
            core.Movement.Flip();
            stateMachine.ChangeState(enemy.moveState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
