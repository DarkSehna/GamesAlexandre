using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorS_IdleState : IdleState
{
    private ArmoredSlime boss;
    public ArmorS_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, ArmoredSlime boss) : base(entity, stateMachine, animBoolName, stateData)
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
            stateMachine.ChangeState(boss.chargeState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
