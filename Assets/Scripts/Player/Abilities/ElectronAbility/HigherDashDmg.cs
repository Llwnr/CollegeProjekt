using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HigherDashDmg", menuName = "CollegeProjekt/ElectronAbilities/HigherDashDamage", order = 0)]
public class HigherDashDmg : ElectronAbility
{
    public float _multiplier;
    private float origMultiplier = 0;
    public float selfDmgIncreaserPercent;
    public override void Activate()
    {
        base.Activate();
        origMultiplier = player.GetComponent<PlayerStats>().GetDashDmgMultiplier();
        player.GetComponent<PlayerStats>().SetDashDmgMultiplier(origMultiplier*_multiplier);
        player.GetComponent<HealthManager>().SetDmgReduction(-selfDmgIncreaserPercent);
    }

    public override void Deactivate()
    {
        player.GetComponent<PlayerStats>().SetDashDmgMultiplier(origMultiplier);
        player.GetComponent<HealthManager>().SetDmgReduction(0);
    }
}
