﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator anim { get; private set; }
    public PlayerInputHandler inputHandler { get; private set; }
    public Rigidbody2D rB { get; private set; }
    #endregion

    #region State Variables
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerInAirState inAirState { get; private set; }
    public PlayerLandState landState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallGrabState wallGrabState { get; private set; }
    public PlayerWallClimbState wallClimbState { get; private set; }


    [SerializeField]
    private PlayerData playerData;
    private Vector2 workSpace;
    #endregion

    #region Other Variables
    public Vector2 currentVelocity;
    public int facingDirection;
    #endregion

    #region Check Transforms
    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private Transform wallCheck;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, playerData, "idle");
        moveState = new PlayerMoveState(this, stateMachine, playerData, "move");
        jumpState = new PlayerJumpState(this, stateMachine, playerData, "inAir");
        inAirState = new PlayerInAirState(this, stateMachine, playerData, "inAir");
        landState = new PlayerLandState(this, stateMachine, playerData, "land");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, playerData, "wallSlide");
        wallGrabState = new PlayerWallGrabState(this, stateMachine, playerData, "wallGrab");
        wallClimbState = new PlayerWallClimbState(this, stateMachine, playerData, "wallClimb");
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        inputHandler = GetComponent<PlayerInputHandler>();
        rB = GetComponent<Rigidbody2D>();

        facingDirection = 1;
        stateMachine.Inicialize(idleState);
    }
    private void Update()
    {
        currentVelocity = rB.velocity;
        stateMachine.currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions
    public void setVelocityX(float velocity)
    {
        workSpace.Set(velocity, currentVelocity.y);
        rB.velocity = workSpace;
        currentVelocity = workSpace;
    }

    public void SetVelocityY(float velocity)
    {
        workSpace.Set(currentVelocity.x, velocity);
        rB.velocity = workSpace;
        currentVelocity = workSpace;
    }
    #endregion

    #region Check Functions

     public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput!=0&&xInput!=facingDirection)
        {
            Flip();
        }
    }
    #endregion

    #region Other Functions
    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }

    private void AnimationTrigger()
    {
        stateMachine.currentState.AnimationTrigger();
    }

    private void AnimationFinishTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }
    #endregion
}