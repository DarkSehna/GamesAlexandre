using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist_PlayerDetectedState : PlayerDetectedState
{
    private Scientist enemy;
    public Scientist_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Scientist enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (performLongRangeAction)
        {
            if (enemy.outOfAmmo)
            {
                stateMachine.ChangeState(enemy.fleeState);
            }
            else
            {
                stateMachine.ChangeState(enemy.rangedAttackState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
