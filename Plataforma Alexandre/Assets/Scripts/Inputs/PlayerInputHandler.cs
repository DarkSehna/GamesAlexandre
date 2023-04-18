using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;
    private PlayerInput playerInput;
    private Camera cam;
    public float cameraMinY = 0.4f;
    public float cameraMaxY = 0.6f;
    public CinemachineVirtualCamera virtualCamera;
    public Vector2 rawMovementInput { get; private set; }
    public Vector2 rawShotDirectionInput { get; private set; }
    public Vector2Int shotDirectionInput { get; private set; }
    public int normInputX { get; private set; }
    public int normInputY { get; private set; }
    public bool jumpInput { get; private set; }
    public bool jumpInputStop { get; private set; }
    public bool[] attackInputs { get; private set; }
    public powerInputs currentPower { get; private set; }
    public bool[] collectedPowers { get; set; }
    public bool ammoGatherInput { get; private set; }
    public bool interactInput { get; private set; }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
        int count = Enum.GetValues(typeof(combatInputs)).Length;
        attackInputs = new bool[count];

        collectedPowers = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false
        };
    }

    void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            attackInputs[(int)combatInputs.primary] = true;
        }
        if(context.canceled)
        {
            attackInputs[(int)combatInputs.primary] = false;
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            attackInputs[(int)combatInputs.secondary] = true;
        }
        if (context.canceled)
        {
            attackInputs[(int)combatInputs.secondary] = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        rawMovementInput = context.ReadValue<Vector2>();
        normInputX = (int)(rawMovementInput * Vector2.right).normalized.x;
        normInputY = (int)(rawMovementInput * Vector2.up).normalized.y;

        float lerpValue = (normInputY + 1) / 2f;
        virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = Mathf.Lerp(cameraMinY, cameraMaxY, lerpValue);
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

    #region OnPowerSetInputs
    public void OnBouncePowerSetInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(collectedPowers[(int)powerInputs.bounce])
            {
                currentPower = powerInputs.bounce;
                //Debug.Log(" bounce ");
            }
        }
    }

    public void OnBubblePowerSetInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (collectedPowers[(int)powerInputs.bubble])
            {
                currentPower = powerInputs.bubble;
                //Debug.Log(" bubble ");
            }
        }
    }

    public void OnGrapplePowerSetInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (collectedPowers[(int)powerInputs.grapple])
            {
                currentPower = powerInputs.grapple;
                //Debug.Log(" grapple ");
            }
        }
    }

    public void OnAntiGPowerSetInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (collectedPowers[(int)powerInputs.antiG])
            {
                currentPower = powerInputs.antiG;
                //Debug.Log(" antiG ");
            }
        }
    }

    public void OnClonePowerSetInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (collectedPowers[(int)powerInputs.clone])
            {
                currentPower = powerInputs.clone;
                //Debug.Log(" clone ");
            }
        }
    }

    #endregion

    public void OnAmmoGatherInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ammoGatherInput = true;
        }
        if (context.canceled)
        {
            ammoGatherInput = false;
        }
    }

    public void OnShotDirectionInput(InputAction.CallbackContext context)
    {
        rawShotDirectionInput = context.ReadValue<Vector2>();
        rawShotDirectionInput = cam.ScreenToWorldPoint((Vector3)rawShotDirectionInput);
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            interactInput = true;
        }
        if (context.canceled)
        {
            interactInput = false;
        }
    }

    public void UseJumpInput() => jumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time > jumpInputStartTime+inputHoldTime)
        {
            jumpInput = false;
        }
    }

}

public enum combatInputs 
{ 
    primary,
    secondary
}

public enum powerInputs
{
    empty,
    bounce,
    antiG,
    bubble,
    grapple,
    clone
}
