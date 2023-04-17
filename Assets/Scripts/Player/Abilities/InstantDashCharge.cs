using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InstantDashCharge", menuName = "CollegeProjekt/InstantDashCharge", order = 0)]
public class InstantDashCharge : Ability
{
    public override void Activate()
    {
        base.Activate();   
    }

    public override void Deactivate()
    {
        
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        ballDash.SetChargeToMax();
    }
}
