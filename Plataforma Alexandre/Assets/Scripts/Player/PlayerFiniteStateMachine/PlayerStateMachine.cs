using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState;

    public void Inicialize(PlayerState stringState)
    {
        currentState = stringState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
