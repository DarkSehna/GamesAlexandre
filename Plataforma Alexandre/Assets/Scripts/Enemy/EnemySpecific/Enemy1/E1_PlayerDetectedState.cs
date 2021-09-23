﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetectedState : PlayerDetectedState
{
    private Enemy1 enemy;
    public E1_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if(performLongRangeAction)
        {
            stateMachine.ChangeState(enemy.chargeState);
        }
        else if(!isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPLayerState);
        }
        else if(!isDetectingLedge)
        {
            core.Movement.Flip();
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
