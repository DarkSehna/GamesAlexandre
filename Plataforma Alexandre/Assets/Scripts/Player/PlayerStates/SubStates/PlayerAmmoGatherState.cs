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

        Reload();
        DestroyPowers();
        isAbilityDone = true;
    }

    public void Reload()
    {
        for (int i = 0; i < playerData.maxAmmo.Length; i++)
        {
            playerData.ammo[i] = playerData.maxAmmo[i];
        }
    }

    private void DestroyPowers()
    {
        foreach (Transform child in player.powerRepository.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
