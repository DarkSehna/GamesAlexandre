using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredSlime : Entity
{
    public ArmorS_IdleState idleState { get; private set; }
    public ArmorS_ChargeState chargeState { get; private set; }
    public ArmorS_HitState hitState { get; private set; }
    public ArmorS_DeadState deadState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_StunState hitStateData;
    [SerializeField] private D_DeadState deadStateData;

    [SerializeField] public Transform meleeAttackPosition;

    public override void Awake()
    {
        base.Awake();

        idleState = new ArmorS_IdleState(this, stateMachine, "idle", idleStateData, this);
        chargeState = new ArmorS_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        hitState = new ArmorS_HitState(this, stateMachine, "hit", hitStateData, this);
        deadState = new ArmorS_DeadState(this, stateMachine, "dead", deadStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        //Gizmos.DrawWireSphere(meleeAttackPosition.position + (Vector3)(Vector2.right * meleeAttackPosition.position), chargeStateData.collisionRadius);
        Gizmos.DrawWireSphere(meleeAttackPosition.position, chargeStateData.collisionRadius);
    }
}
