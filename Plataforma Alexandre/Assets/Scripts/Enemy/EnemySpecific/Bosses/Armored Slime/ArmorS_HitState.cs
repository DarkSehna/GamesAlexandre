using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorS_HitState : StunState
{
    private ArmoredSlime boss;
    public ArmorS_HitState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData, ArmoredSlime boss) : base(entity, stateMachine, animBoolName, stateData)
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

        if(isStunTimeOver)
        {
            core.Movement.Flip();
            stateMachine.ChangeState(boss.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
