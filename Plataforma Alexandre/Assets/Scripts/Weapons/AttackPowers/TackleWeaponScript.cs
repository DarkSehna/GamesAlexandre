using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TackleWeaponScript : AgressiveWeapon
{
    protected SO_TackleWeaponData tackleWeaponData;
    
    public override void AnimationStartMovementTrigger()
    {
        core.Movement.SetVelocityX(tackleWeaponData.tackleSpeed * core.Movement.facingDirection);
    }
}
