using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponents, IDamageable, IKnockbackable
{
    private bool isKnockbackActive;
    private float knockbackStartTime;
    [SerializeField] private float maxKnockbackTime = 0.2f;
    
    public void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + "damaged");
        core.Stats.DecreaseHealth(amount);
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);
        core.Movement.CanSetVelocity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if(isKnockbackActive && core.Movement.currentVelocity.y <= 0.01f && (core.CollisionSenses.Ground || Time.time >= knockbackStartTime + maxKnockbackTime))
        {
            isKnockbackActive = false;
            core.Movement.CanSetVelocity = true;
        }
    }
}
