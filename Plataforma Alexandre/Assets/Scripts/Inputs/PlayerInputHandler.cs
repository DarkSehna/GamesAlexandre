using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;
    private float dashInputStartTime;
    private PlayerInput playerInput;
    private Camera cam;
    public Vector2 rawMovementInput { get; private set; }
    public Vector2 rawDashDirectionInput { get; private set; }
    public Vector2Int dashDirectionInput { get; private set; }
    public int normInputX { get; private set; }
    public int normInputY { get; private set; }
    public bool jumpInput { get; private set; }
    public bool jumpInputStop { get; private set; }
    public bool grabInput { get; private set; }
    public bool dashInput { get; private set; }
    public bool dashInputStop { get; private set; }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
    }

    void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        rawMovementInput = context.ReadValue<Vector2>();
        normInputX = (int)(rawMovementInput * Vector2.right).normalized.x;
        normInputY = (int)(rawMovementInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    { 
        if (context.started)
        {
            jumpInput = true;
            jumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if(context.canceled)
        {
            jumpInputStop = true;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            grabInput = true;
        }

        if(context.canceled)
        {
            grabInput = false;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            dashInput = true;
            dashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if(context.canceled)
        {
            dashInputStop = true;
        }
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        rawDashDirectionInput = context.ReadValue<Vector2>();

        if(playerInput.currentControlScheme == "GameKeyboard")
        {
            rawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)rawDashDirectionInput) - transform.position;
        }

        dashDirectionInput = Vector2Int.RoundToInt(rawDashDirectionInput.normalized);
    }

    public void UseJumpInput() => jumpInput = false;

    public void UseDashInput() => dashInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time > jumpInputStartTime+inputHoldTime)
        {
            jumpInput = false;
        }
    }

    private void CheckDashInputHoldTime()
    {
        if(Time.time >= dashInputStartTime+inputHoldTime)
        {
            dashInput = false;
        }
    }
}
