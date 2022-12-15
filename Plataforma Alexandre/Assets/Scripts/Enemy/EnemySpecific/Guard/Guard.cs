using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Entity
{
    public Guard_IdleState idleState { get; private set; }
    public Guard_MoveState moveState { get; private set; }
    public Guard_PlayerDetectedState playerDetectedState { get; private set; }
    public Guard_LookForPlayerState lookForPlayerState { get; private set; }
    public Guard_StunState stunState { get; private set; }
    public Guard_DeadState deadState { get; private set; }
    public Guard_AttackState attackState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetected playerDetectedStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerStateData;
    [SerializeField] private D_StunState stunStateData;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] private D_RangedAttackState attackStateData;

    [SerializeField] private Transform rangedAttackPosition;

    public override void Awake()
    {
        base.Awake();

        idleState = new Guard_IdleState(this, stateMachine, "idle", idleStateData, this);
        moveState = new Guard_MoveState(this, stateMachine, "move", moveStateData, this);
        playerDetectedState = new Guard_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        lookForPlayerState = new Guard_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new Guard_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new Guard_DeadState(this, stateMachine, "dead", deadStateData, this);
        attackState = new Guard_AttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, attackStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(playerDetectedState);

    }
}
