using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_LookForPlayerState lookForPLayerState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }
    public E1_MeleeAttackState meleeAttackState { get; private set; }
    public E1_DeadState deadState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_StunState stunState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerData;
    [SerializeField] private D_PlayerDetected playerDetectedData;
    [SerializeField] private D_MeleeAttackState meleeAttackStateData;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_StunState stunStateData;

    [SerializeField] private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(this, stateMachine, "Move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "Idle", idleStateData, this);
        lookForPLayerState = new E1_LookForPlayerState(this, stateMachine, "LookForPlayer", lookForPlayerData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMachine, "PlayerDetected", playerDetectedData, this);
        meleeAttackState = new E1_MeleeAttackState(this, stateMachine, "MeleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        deadState = new E1_DeadState(this, stateMachine, "Dead", deadStateData, this);
        chargeState = new E1_ChargeState(this, stateMachine, "Charge", chargeStateData, this);
        stunState = new E1_StunState(this, stateMachine, "Stun", stunStateData, this);

        stateMachine.Initialize(moveState);
    }
}
