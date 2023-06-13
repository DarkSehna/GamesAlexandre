using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Core Core { get; private set; }
    public Animator anim { get; private set; }
    public PlayerInputHandler inputHandler { get; private set; }
    public Rigidbody2D rB { get; private set; }
    public Transform dashDirectionIndicator { get; private set; }
    public BoxCollider2D movementCollider { get; private set; }
    public PlayerInventory inventory { get; private set; }
    public Transform powerRepository { get; private set; }
    public Transform aimDirectionIndicator { get; private set; }
    #endregion

    #region State Variables
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirControlState inAirState { get; private set; }
    public PlayerAirImpulseState airImpulseState { get; private set; }
    public PlayerLandState landState { get; private set; }
    public PlayerCrouchIdleState crouchIdleState { get; private set; }
    public PlayerCrouchMoveState crouchMoveState { get; private set; }
    public PlayerAttackState primaryAttackState { get; private set; }
    public PlayerAttackState secondaryAttackState { get; private set; }
    public PlayerAmmoGatherState ammoGatherState { get; private set; }

    [SerializeField]
    public PlayerData playerData;
    private Vector2 workSpace;
    public Vector2 aimDirection;
    private Vector2 aimDirectionInput;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        inputHandler = GetComponent<PlayerInputHandler>();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, playerData, "idle");
        moveState = new PlayerMoveState(this, stateMachine, playerData, "move");
        jumpState = new PlayerJumpState(this, stateMachine, playerData, "inAir");
        inAirState = new PlayerAirControlState(this, stateMachine, playerData, "inAir");
        airImpulseState = new PlayerAirImpulseState(this, stateMachine, playerData, "inAir");
        landState = new PlayerLandState(this, stateMachine, playerData, "land");
        crouchIdleState = new PlayerCrouchIdleState(this, stateMachine, playerData, "crouchIdle");
        crouchMoveState = new PlayerCrouchMoveState(this, stateMachine, playerData, "crouchMove");
        primaryAttackState = new PlayerAttackState(this, stateMachine, playerData, "attack"); 
        secondaryAttackState = new PlayerAttackState(this, stateMachine, playerData, "attack");
        ammoGatherState = new PlayerAmmoGatherState(this, stateMachine, playerData, "ammoGather");
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
        dashDirectionIndicator = transform.Find("DashDirectionIndicator");
        aimDirectionIndicator = transform.Find("AimDirectionIndicator");
        movementCollider = GetComponent<BoxCollider2D>();
        inventory = GetComponent<PlayerInventory>();
        powerRepository = GameObject.Find("AmmoRepository").transform;

        primaryAttackState.SetWeapon(inventory.weapons[(int)combatInputs.primary]);
        secondaryAttackState.SetWeapon(inventory.weapons[(int)combatInputs.secondary]);

        stateMachine.Inicialize(idleState);

        ammoGatherState.Reload();

        playerData.lastCheckpointPos = gameObject.transform.position;
    }
    private void Update()
    {
        if(!inputHandler.pauseGameInput && !inputHandler.openWheelInput)
        {
            Core.LogicUpdate();
            stateMachine.currentState.LogicUpdate();
            AimDirection();
        }
    }
    private void FixedUpdate()
    {
        if (!inputHandler.pauseGameInput && !inputHandler.openWheelInput)
        {
            stateMachine.currentState.PhysicsUpdate();
        }
    }
    #endregion

    #region Other Functions

    private void AnimationTrigger()
    {
        stateMachine.currentState.AnimationTrigger();
    }

    private void AnimationFinishTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }

    public void SetColliderHeight(float height)
    {
        Vector2 center = movementCollider.offset;
        workSpace.Set(movementCollider.size.x, height);

        center.y += (height - movementCollider.size.y) / 2;

        movementCollider.size = workSpace;
        movementCollider.offset = center;
    }

    public void AimDirection()
    {
        aimDirectionInput = inputHandler.shotDirectionInput;
        aimDirection = aimDirectionInput;
        aimDirection.Normalize();
        float angle = Vector2.SignedAngle(Vector2.right, aimDirection);
        aimDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }

    public void SetWeapon()
    {
        primaryAttackState.SetWeapon(inventory.weapons[(int)combatInputs.tackle]); 
    }
}
