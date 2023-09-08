using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : Entity
{
    public Janitor_IdleState idleState { get; private set; }
    public Janitor_MoveState moveState { get; private set; }
    public Janitor_PlayerDetectedState playerDetectedState { get; private set; }
    public Janitor_ChargeState chargeState { get; private set; }
    public Janitor_MeleeAttackState meleeAttackState { get; private set; }
    public Janitor_LookForPlayerState lookForPlayerState { get; private set; }
    public Janitor_DeadState deadState { get; private set; }
    public Janitor_RangedAttackState rangedAttackState { get; private set; }

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

    public bool outOfAmmo { get; set; }

    public override void Awake()
    {
        base.Awake();

        outOfAmmo = false;

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

    public override void Update()
    {
        base.Update();
        if (Core.Stats.currentHealth <= 0)
        {
            Core.Stats.currentHealth = 0;
            stateMachine.ChangeState(deadState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}
