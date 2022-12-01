using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Scientist : Entity
{
    public Scientist_IdleState idleState { get; private set; }
    public Scientist_MoveState moveState { get; private set; }
    public Scientist_PlayerDetectedState playerDetectedState { get; private set; }
    public Scientist_DeadState deadState { get; private set; }
    public Scientist_RangedAttackState rangedAttackState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetected playerDetectedStateData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_MeleeAttackState meleeAttackStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerStateData;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] private D_RangedAttackState rangedAttackStateData;

    [SerializeField] private Transform meleeAttackPosition;
    [SerializeField] private Transform rangedAttackPosition;

    public override void Awake()
    {
        base.Awake();

        idleState = new Janitor_IdleState(this, stateMachine, "idle", idleStateData, this);
        moveState = new Janitor_MoveState(this, stateMachine, "move", moveStateData, this);
        playerDetectedState = new Janitor_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        chargeState = new Janitor_ChargeState(this, stateMachine, "chargeState", chargeStateData, this);
        meleeAttackState = new Janitor_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new Janitor_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        deadState = new Janitor_DeadState(this, stateMachine, "dead", deadStateData, this);
        rangedAttackState = new Janitor_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);

    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}*/
