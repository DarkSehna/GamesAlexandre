using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSlime_DeadState : DeadState
{
    private RedSlime enemy;

    public RSlime_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, RedSlime enemy) : base(entity, stateMachine, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
