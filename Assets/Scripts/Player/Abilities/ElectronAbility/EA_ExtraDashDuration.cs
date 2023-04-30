using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EA_ExtraDashDuration", menuName = "CollegeProjekt/ElectronAbilities/EA_ExtraDashDuration", order = 0)]
public class EA_ExtraDashDuration : ElectronAbility
{
    public float extraDashDuration;
    public override void Activate()
    {
        base.GetReferences();
        player.GetComponent<BallDash>().IncreaseDashDuration(extraDashDuration);
    }

    public override void Deactivate()
    {
    }
}
