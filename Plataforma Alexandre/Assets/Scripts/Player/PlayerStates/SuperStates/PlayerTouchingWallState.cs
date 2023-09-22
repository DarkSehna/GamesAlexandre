using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{
    protected int yInput;
    protected int xInput;
    protected bool jumpInput;

    protected bool isGrounded;
    protected bool isTouchingWall;
    protected bool isTouchingLedge;

    public PlayerTouchingWallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        isGrounded = core.CollisionSenses.Ground;
        isTouchingWall = core.CollisionSenses.WallFront;
        isTouchingLedge = core.CollisionSenses.LedgeHorizontal;
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

        xInput = player.inputHandler.normInputX;
        yInput = player.inputHandler.normInputY;
        jumpInput = player.inputHandler.jumpInput;

        if(isGrounded)
        {
            stateMachine.ChangeState(player.idleState);
        }
        else if(!isTouchingWall || xInput != core.Movement.facingDirection)
        {
            stateMachine.ChangeState(player.inAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
