using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSlime : Entity
{
    public RSlime_IdleState idleState { get; private set; }
    public RSlime_MoveState moveState { get; private set; }
    public RSlime_PlayerDetected playerDetectedState { get; private set; }
    public RSlime_ChargeState chargeState { get; private set; }
    public RSlime_LookForPlayer lookForPlayerState { get; private set; }
    public RSlime_StunState stunState { get; private set; }
    public RSlime_DeadState deadState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetected playerDetectedStateData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_LookForPlayer lokForPlayerStateData;
    [SerializeField] private D_StunState stunStateData;
    [SerializeField] private D_DeadState deadStateData;

    [SerializeField] public Transform meleeAttackPosition;

    public override void Awake()
    {
        base.Awake();

        idleState = new RSlime_IdleState(this, stateMachine, "idle", idleStateData, this);
        moveState = new RSlime_MoveState(this, stateMachine, "move", moveStateData, this);
        playerDetectedState = new RSlime_PlayerDetected(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        chargeState = new RSlime_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new RSlime_LookForPlayer(this, stateMachine, "lookForPlayer", lokForPlayerStateData, this);
        stunState = new RSlime_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new RSlime_DeadState(this, stateMachine, "dead", deadStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
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

        Gizmos.DrawWireSphere(meleeAttackPosition.position, chargeStateData.collisionRadius);
    }
}
