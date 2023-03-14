using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponents
{
    public Rigidbody2D rB { get; private set; }
    public int facingDirection { get; private set; }
    public bool CanSetVelocity { get; set; }
    public bool isDriven { get; set; }
    public Vector2 currentVelocity { get; private set; }
    private Vector2 workSpace;

    public Vector2 maxControllableVelocity;

    protected override void Awake()
    {
        base.Awake();

        rB = GetComponentInParent<Rigidbody2D>();
        facingDirection = 1;
        CanSetVelocity = true;
        isDriven = false;
    }

    public override void LogicUpdate()
    {
        currentVelocity = rB.velocity;
        CheckIfIsDriven();
    }

    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, currentVelocity.y);
        SetFinalVelocity();
    }

    public void SetVelocityY(float velocity)
    {
        workSpace.Set(currentVelocity.x, velocity);
        SetFinalVelocity();
    }

    public void SetVelocityZero()
    {
        workSpace = Vector2.zero;
        SetFinalVelocity();
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetFinalVelocity();
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workSpace = direction * velocity;
        SetFinalVelocity();
    }

    private void SetFinalVelocity()
    {
        if(CanSetVelocity)
        {
            rB.velocity = workSpace;
            currentVelocity = workSpace;
        }
    }

    public void CheckIfIsDriven()
    {
        if(Mathf.Abs(currentVelocity.x) < Mathf.Abs(maxControllableVelocity.x))
        {
            isDriven = false;
        }
        else
        {
            isDriven = true;
        }
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != facingDirection)
        {
            Flip();
        }
    }

    public void Flip()
    {
        facingDirection *= -1;
        rB.transform.Rotate(0f, 180f, 0f);
    }
}
