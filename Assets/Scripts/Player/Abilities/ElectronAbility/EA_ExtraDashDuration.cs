using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EA_ExtraDashDuration", menuName = "CollegeProjekt/ElectronAbilities/EA_ExtraDashDuration", order = 0)]
public class EA_ExtraDashDuration : ElectronAbility
{
    public float extraDashDuration;
    public float slowDownFactor;
    public override void Activate()
    {
        base.GetReferences();
        player.GetComponent<BallDash>().IncreaseDashDuration(extraDashDuration);
        player.GetComponent<Rigidbody2D>().velocity *= 1-slowDownFactor;
    }

    public override void Deactivate()
    {
    }
}
