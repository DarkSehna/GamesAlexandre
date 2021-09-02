﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_LookForPlayerState : LookForPlayerState
{
    private Enemy2 enemy;
    public E2_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }
}
