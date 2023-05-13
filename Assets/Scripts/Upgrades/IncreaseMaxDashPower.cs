using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaxDashUpgrade", menuName = "CollegeProjekt/Upgrades/MaxDash+", order = 0)]
public class IncreaseMaxDashPower : Upgrade
{
    public float increaseBy;
    public override void Activate()
    {
        GetReferences();
        ballDash.SetBuffedMaxSpeed(ballDash.GetBuffedMaxSpeed()+increaseBy);
    }
}
