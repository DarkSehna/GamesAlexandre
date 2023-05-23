using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirControlState : PlayerInAirState
{
    public PlayerAirControlState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        core.Movement.CheckIfShouldFlip(xInput);
        core.Movement.SetVelocityX(playerData.movementVelocity * xInput);

        player.anim.SetFloat("yVelocity", core.Movement.currentVelocity.y);
        player.anim.SetFloat("xVelocity", Mathf.Abs(core.Movement.currentVelocity.x));

        if(isDriven)
        {
            stateMachine.ChangeState(player.airImpulseState);
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}