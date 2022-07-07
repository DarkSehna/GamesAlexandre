using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmoGatherState : PlayerAbilityState
{
    public PlayerAmmoGatherState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    private bool ammoGatherInput;

    public override void Enter()
    {
        base.Enter();

        isAbilityDone = true;
    }
}
