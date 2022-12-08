using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : Entity
{
    public Scientist_IdleState idleState { get; private set; }
    public Scientist_MoveState moveState { get; private set; }
    public Scientist_LookForPlayerState lookForPlayerState { get; private set; }
    public Scientist_PlayerDetectedState playerDetectedState { get; private set; }
    public Scientist_DeadState deadState { get; private set; }
    public Scientist_RangedAttackState rangedAttackState { get; private set; }
    public Scientist_FleeState fleeState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerStateData;
    [SerializeField] private D_PlayerDetected playerDetectedStateData;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] private D_RangedAttackState rangedAttackStateData;
    [SerializeField] private D_FleeState fleeStateData;

    [SerializeField] private Transform rangedAttackPosition;

    public bool outOfAmmo { get; set; }

    public override void Awake()
    {
        base.Awake();

        outOfAmmo = false;

        idleState = new Scientist_IdleState(this, stateMachine, "idle", idleStateData, this);
        moveState = new Scientist_MoveState(this, stateMachine, "move", moveStateData, this); 
        lookForPlayerState = new Scientist_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        playerDetectedState = new Scientist_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        deadState = new Scientist_DeadState(this, stateMachine, "dead", deadStateData, this);
        rangedAttackState = new Scientist_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);
        fleeState = new Scientist_FleeState(this, stateMachine, "flee", fleeStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);

    }
}
