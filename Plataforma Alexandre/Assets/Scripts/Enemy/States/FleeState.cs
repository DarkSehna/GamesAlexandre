using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : State
{
    protected D_FleeState stateData;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isFleeTimeOver;

    public FleeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_FleeState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isDetectingLedge = core.CollisionSenses.LedgeVertical;
        isDetectingWall = core.CollisionSenses.WallFront;
    }

    public override void Enter()
    {
        base.Enter();

        isFleeTimeOver = false;
        core.Movement.Flip();
        core.Movement.SetVelocityX(stateData.fleeSpeed * core.Movement.facingDirection);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityX(stateData.fleeSpeed * core.Movement.facingDirection);
        if (Time.time > startTime + stateData.fleeTime && stateData.fleeForever)
        {
            isFleeTimeOver = true;
        }
    }
}
