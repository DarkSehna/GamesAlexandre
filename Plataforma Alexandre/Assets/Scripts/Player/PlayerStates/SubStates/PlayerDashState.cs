﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool canDash {get; private set;}
    private bool isHolding;
    private bool dashInputStop;
    private float lastDashTime;
    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;
    private Vector2 lastAIPos;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        canDash = false;
        player.inputHandler.UseDashInput();

        isHolding = true;
        dashDirection = Vector2.right * player.facingDirection;

        Time.timeScale = playerData.holdTimeScale;
        startTime = Time.unscaledTime;
        player.dashDirectionIndicator.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();

        if(player.currentVelocity.y > 0)
        {
            core.Movement.SetVelocityY(player.currentVelocity.y * playerData.dashEndYMultiplier);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            player.anim.SetFloat("yVelocity", player.currentVelocity.y);
            player.anim.SetFloat("xVelocity", Mathf.Abs(player.currentVelocity.x));
            
            if(isHolding)
            {
                dashDirectionInput = player.inputHandler.dashDirectionInput;
                dashInputStop = player.inputHandler.dashInputStop;

                if(dashDirectionInput != Vector2.zero)
                {
                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
                player.dashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

                if(dashInputStop || Time.unscaledTime >= startTime + playerData.maxHoldTime)
                {
                    isHolding = false;
                    Time.timeScale = 1f;
                    startTime = Time.time;
                    core.Movement.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                    player.rB.drag = playerData.drag;
                    core.Movement.SetVelocity(playerData.dashVelocity, dashDirection);

                    player.dashDirectionIndicator.gameObject.SetActive(false);
                    PlaceAfterImage();
                }
            }
            else
            {
                core.Movement.SetVelocity(playerData.dashVelocity, dashDirection);
                CheckIfShouldPlaceAfterImage();

                if (Time.time >= startTime + playerData.dashTime)
                {
                    player.rB.drag = 0f;
                    isAbilityDone = true;
                    lastDashTime = Time.time;
                }
            }
        }
    }

    private void CheckIfShouldPlaceAfterImage()
    {
        if(Vector2.Distance(player.transform.position,lastAIPos) >= playerData.distanceBetweenAfterimages)
        {
            PlaceAfterImage();
        }
    }

    private void PlaceAfterImage()
    {
        //playerAfterImagePool.Instance.GetFromPool();
        lastAIPos = player.transform.position;
    }

    public bool CheckIfCanDash()
    {
        return canDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    public void ResetCanDash() => canDash = true;
}
