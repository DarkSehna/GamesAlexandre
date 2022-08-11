using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponents, IDamageable, IKnockbackable
{
    private bool isKnockbackActive;
    private float knockbackStartTime;
    [SerializeField] private float maxKnockbackTime = 0.2f;
    
    public override void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount, GameObject collider)
    {
        Debug.Log(core.transform.parent.name + "damaged");
        if(collider.tag == "Water")
        {
            core.Stats.DecreaseHealth(amount);
            core.Stats.WaterRespawn();
        }
        else
        {
            core.Stats.DecreaseHealth(amount);
        }
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
