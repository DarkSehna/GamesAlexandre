using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    protected int xInput;
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected bool isTouchingWallBack;
    protected bool isTouchingCeiling;
    protected bool oldIsTouchingWall;
    protected bool oldIsTouchingWallBack;
    protected bool isTouchingLedge;
    protected bool jumpInput;
    protected bool jumpInputStop;
    protected bool isJumping;
    protected bool coyoteTime;

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
        isTouchingCeiling = core.CollisionSenses.Ceiling;
        isTouchingLedge = core.CollisionSenses.LedgeHorizontal;

    }

    public override void Enter()
    {
        base.Enter();

        playerData.launchStartTime = Time.time;
    }

    public override void Exit()
    {
        base.Exit();

        oldIsTouchingWall = false;
        oldIsTouchingWallBack = false;
        isTouchingWall = false;
        isTouchingWallBack = false;

        if(!core.Movement.CanSetVelocity)
        {
            core.Movement.CanSetVelocity = true;
            //Debug.Log("Launch End");
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();
        xInput = player.inputHandler.normInputX;
        jumpInput = player.inputHandler.jumpInput;
        jumpInputStop = player.inputHandler.jumpInputStop;
        CheckJumpMultiplier();

        core.Movement.CheckIfShouldFlip(xInput);
        core.Movement.SetVelocityX(playerData.movementVelocity * xInput);

        player.anim.SetFloat("yVelocity", core.Movement.currentVelocity.y);
        player.anim.SetFloat("xVelocity", Mathf.Abs(core.Movement.currentVelocity.x));

        if (isGrounded && core.Movement.currentVelocity.y<0.01f)
        {
            stateMachine.ChangeState(player.landState);
        }
        else if(jumpInput && player.jumpState.CanJump())
        {
            stateMachine.ChangeState(player.jumpState);
        }

        if (Time.time >= playerData.launchStartTime + playerData.launchEndTime)// || isTouchingCeiling || isTouchingWall || isTouchingWallBack)
        {
            //Debug.Log("Launch End");
            core.Movement.CanSetVelocity = true;
        }
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
    
    public void StartCoyoteTime()
    {
        coyoteTime = true;
    }

    public void SetIsJumping()
    {
        isJumping = true;
    }
}
