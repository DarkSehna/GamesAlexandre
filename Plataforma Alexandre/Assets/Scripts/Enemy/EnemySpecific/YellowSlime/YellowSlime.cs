using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSlime : Entity
{
    public YSlime_IdleState idleState { get; private set; }
    public YSlime_MoveState moveState {get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private Transform hitPosition;

    public override void Awake()
    {
        base.Awake();

        moveState = new YSlime_MoveState(this, stateMachine, "move", moveStateData, this, hitPosition);
        idleState = new YSlime_IdleState(this, stateMachine, "idle", idleStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);
    }
}
