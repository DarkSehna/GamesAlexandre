using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    private Weapon weapon;
    private int xInput;
    private float velocityToSet;
    private bool setVelocity;
    private bool shouldCheckFlip;

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void Enter()
    {
        base.Enter();

        setVelocity = false;
        weapon.EnterWeapon(playerData.objectToSpawn[(int)player.inputHandler.currentPower]);
    }

    public override void Exit()
    {
        base.Exit();
        weapon.ExitWeapon();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.inputHandler.normInputX;
        if(shouldCheckFlip)
        {
            core.Movement.CheckIfShouldFlip(xInput);
        }
        if(setVelocity)
        {
            core.Movement.SetVelocityX(velocityToSet * core.Movement.facingDirection);
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        weapon.InitializeWeapon(this, core);
    }

    public void SetPlayerVelocity(float velocity)
    {
        core.Movement.SetVelocityX(velocity * core.Movement.facingDirection);
        velocityToSet = velocity;
        setVelocity = true;
    }

    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }
}
