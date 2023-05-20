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
        //Also increase the frames for max charge
        ballDash.IncreaseFramesForMaxChargeBy(increaseBy*0.5f);//Every 2 increase in dash speed, the charge taken for max charge is increased by 1
    }
}
