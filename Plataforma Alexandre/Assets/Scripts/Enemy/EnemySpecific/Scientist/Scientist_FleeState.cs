using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist_FleeState : FleeState
{
    Scientist enemy;

    public Scientist_FleeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_FleeState stateData, Scientist enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
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

        if (!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if (isDetectingInteractable) //Escape door
        {
            GameObject.Instantiate(stateData.objectToSpawn, entity.gameObject.transform.position + new Vector3(0, 0), entity.gameObject.transform.rotation);
            GameObject.Instantiate(stateData.objectToSpawn, entity.gameObject.transform.position + new Vector3(-1, 0), entity.gameObject.transform.rotation); 
            entity.gameObject.SetActive(false);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
