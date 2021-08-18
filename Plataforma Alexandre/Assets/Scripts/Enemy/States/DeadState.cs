using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    protected D_DeadState stateData;
    public DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(stateData.deadBloodParticle, entity.aliveGO.transform.position, stateData.deadBloodParticle.transform.rotation);
        GameObject.Instantiate(stateData.deadChunckParticle, entity.aliveGO.transform.position, stateData.deadChunckParticle.transform.rotation);
        entity.gameObject.SetActive(false);
    }
}
