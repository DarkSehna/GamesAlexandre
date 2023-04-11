using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    protected int xInput;
    protected bool isDriven;
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected bool isTouchingWallBack;
    protected bool oldIsTouchingWall;
    protected bool oldIsTouchingWallBack;
    protected bool isTouchingLedge;
    protected bool jumpInput;
    protected bool jumpInputStop;
    protected bool isJumping;
    protected bool grabInput;
    protected bool dashInput;
    protected bool coyoteTime;
    protected bool wallJumpCoyoteTime;
    protected float startWallJumpCoyoteTime;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        oldIsTouchingWall = isTouchingWall;
        oldIsTouchingWallBack = isTouchingWallBack;

        isGrounded = core.CollisionSenses.Ground;
        isTouchingWall = core.CollisionSenses.WallFront;
        isTouchingWallBack = core.CollisionSenses.WallBack;
        isTouchingLedge = core.CollisionSenses.LedgeHorizontal;

        isDriven = core.Movement.isDriven;

        if(isTouchingWall && !isTouchingLedge)
        {
            player.ledgeClimbState.SetDetectedPosition(player.transform.position);
        }

        if(!wallJumpCoyoteTime && !isTouchingWall && !isTouchingWallBack && (oldIsTouchingWall || oldIsTouchingWallBack))
        {
            StartWallJumpCoyoteTime();
        }
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        oldIsTouchingWall = false;
        oldIsTouchingWallBack = false;
        isTouchingWall = false;
        isTouchingWallBack = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();
        CheckWallJumpCoyoteTime();
        xInput = player.inputHandler.normInputX;
        jumpInput = player.inputHandler.jumpInput;
        jumpInputStop = player.inputHandler.jumpInputStop;
        grabInput = player.inputHandler.grabInput;
        dashInput = player.inputHandler.dashInput;
        isDriven = core.Movement.isDriven;
        CheckJumpMultiplier();

        if(isGrounded && core.Movement.currentVelocity.y<0.01f)
        {
            stateMachine.ChangeState(player.landState);
        }
        else if(jumpInput && player.jumpState.CanJump())
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else if(dashInput && player.dashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.dashState);
        }
        //else if(isTouchingWall && !isTouchingLedge && !isGrounded && !isDriven)
        //{
        //    stateMachine.ChangeState(player.ledgeClimbState);
        //}
        //else if(jumpInput && (isTouchingWall || isTouchingWallBack || wallJumpCoyoteTime))
        //{
        //    StopWallJumpCoyoteTime();
        //    isTouchingWall = core.CollisionSenses.WallFront;
        //    player.wallJumpState.DetermineWallJumpDirection(isTouchingWall);
        //    stateMachine.ChangeState(player.wallJumpState);
        //}
        //else if(isTouchingWall && grabInput && isTouchingLedge && !isDriven)
        //{
        //    stateMachine.ChangeState(player.wallGrabState);
        //}
        //else if(isTouchingWall && !isDriven && xInput == core.Movement.facingDirection && core.Movement.currentVelocity.y<=0)
        //{
        //    stateMachine.ChangeState(player.wallSlideState);
        //}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckJumpMultiplier()
    {
        if(isJumping)
        {
            if(jumpInputStop)
            {
                core.Movement.SetVelocityY(core.Movement.currentVelocity.y * playerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if(core.Movement.currentVelocity.y<=0f)
            {
                isJumping = false;
            }
        }
    }

    private void CheckCoyoteTime()
    {
        if(coyoteTime && Time.time>startTime+playerData.coyoteTime)
        {
            coyoteTime = false;
            player.jumpState.DecreaseAmountOfJumpsLeft();
        }
    }
    
    private void CheckWallJumpCoyoteTime()
    {
        if(wallJumpCoyoteTime && Time.time > startWallJumpCoyoteTime + playerData.coyoteTime)
        {
            wallJumpCoyoteTime = false;
        }
    }

    public void StartCoyoteTime()
    {
        coyoteTime = true;
    }

    public void StartWallJumpCoyoteTime()
    {
        wallJumpCoyoteTime = true;
        startWallJumpCoyoteTime = Time.time;
    }

    public void StopWallJumpCoyoteTime()
    {
        wallJumpCoyoteTime = false;
    }

    public void SetIsJumping()
    {
        isJumping = true;
    }
}
