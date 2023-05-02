using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestPowerup", menuName = "CollegeProjekt/Powerups/TestPowerup", order = 0)]
public class TestPowerup : Powerup
{
    public override void Activate()
    {
        base.Activate();
        Debug.Log(name + " activated");
    }

    public override void Deactivate()
    {
        Debug.Log("Deactivated");
    }
}
