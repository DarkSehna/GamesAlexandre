using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;
    private bool jumpInput;
    private bool gatherInput;

    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingLedge;
    protected bool isTouchingCeiling;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        isTouchingCeiling = core.CollisionSenses.Ceiling;
    }

    public override void Enter()
    {
        base.Enter();
        player.jumpState.ResetAmountOfJumpsLeft();
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
        gatherInput = player.inputHandler.ammoGatherInput;

        if (player.inputHandler.attackInputs[(int)combatInputs.primary] && !isTouchingCeiling)
        {
            stateMachine.ChangeState(player.primaryAttackState);
        }
        else if (player.inputHandler.attackInputs[(int)combatInputs.secondary] && !isTouchingCeiling && playerData.ammo[(int)player.inputHandler.currentPower] > 0)
        {
            stateMachine.ChangeState(player.secondaryAttackState);
            playerData.ammo[(int)player.inputHandler.currentPower]--;
        }
        else if (gatherInput && isGrounded)
        {
            stateMachine.ChangeState(player.ammoGatherState);
        }
        else if (jumpInput && player.jumpState.CanJump())
        {
            player.inputHandler.UseJumpInput();
            stateMachine.ChangeState(player.jumpState);
        }
        else if (!isGrounded)
        {
            if(!core.Movement.isDriven)
            {
                player.inAirState.StartCoyoteTime();
                stateMachine.ChangeState(player.inAirState);
            }
            else
            {
                stateMachine.ChangeState(player.airImpulseState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
