using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorS_DeadState : DeadState
{
    private ArmoredSlime boss;
    public ArmorS_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, ArmoredSlime boss) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.boss = boss;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(stateData.itemDrop);
    }
}
