using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSlime_MoveState : MoveState
{
    private YellowSlime enemy;
    public YSlime_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, YellowSlime enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        //base.Enter();

        var vectorUp = new Vector2(20, 0);
        var vectorRight = new Vector2(0, 20);
        var vectorJump = (Vector2.up + Vector2.right).normalized;
        Debug.DrawLine(enemy.transform.position, (Vector3)vectorJump);
        //core.Movement.SetVelocity(stateData.movementSpeed, new Vector2(vectorJump.x * core.Movement.facingDirection, vectorJump.y));
        core.Movement.SetVelocity(20f, Vector2.one, core.Movement.facingDirection);
        stateMachine.ChangeState(enemy.idleState);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        //base.LogicUpdate();

        /*if (isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }*/
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
