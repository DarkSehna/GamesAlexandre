using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponents
{
    public Rigidbody2D rB { get; private set; }
    public int facingDirection { get; private set; }
    public Vector2 currentVelocity { get; private set; }
    private Vector2 workSpace;

    protected override void Awake()
    {
        base.Awake();

        rB = GetComponentInParent<Rigidbody2D>();
        facingDirection = 1;
    }

    public void LogicUpdate()
    {
        currentVelocity = rB.velocity;
    }

    public void SetVelocityX(float velocity)
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

    public void SetVelocityZero()
    {
        rB.velocity = Vector2.zero;
        currentVelocity = Vector2.zero;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        rB.velocity = workSpace;
        currentVelocity = workSpace;
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workSpace = direction * velocity;
        rB.velocity = workSpace;
        currentVelocity = workSpace;
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != facingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }
}
