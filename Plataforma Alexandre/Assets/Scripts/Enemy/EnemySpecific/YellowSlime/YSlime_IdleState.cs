using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSlime_IdleState : IdleState
{
    private YellowSlime enemy;
    public YSlime_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, YellowSlime enemy) : base(entity, stateMachine, animBoolName, stateData)
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
