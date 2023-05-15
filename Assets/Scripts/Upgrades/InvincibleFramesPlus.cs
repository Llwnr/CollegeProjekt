using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InvincibleFramesPlus", menuName = "CollegeProjekt/Upgrades/InvincibleFrames+", order = 0)]
public class InvincibleFramesPlus : Upgrade
{
    public float increaseBy;
    public override void Activate()
    {
        GetReferences();
        GameObject dashBomb = GameObject.FindWithTag("Bomb");
        dashBomb.transform.localScale += Vector3.one*increaseBy;
    }
}
