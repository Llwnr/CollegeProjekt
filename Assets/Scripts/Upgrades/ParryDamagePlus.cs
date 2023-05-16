using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParryDamagePlus", menuName = "CollegeProjekt/Upgrades/ParryDamagePlus+", order = 0)]
public class ParryDamagePlus : Upgrade
{
    public float increaseBy;
    public override void Activate()
    {
        GetReferences();
        playerStats.IncreaseParryDmg(increaseBy);
    }
}
