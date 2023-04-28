using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HigherDashDmg", menuName = "CollegeProjekt/DashAbilities/HigherDashDamage", order = 0)]
public class HigherDashDmg : DashAbility
{
    public float _multiplier;
    private float origMultiplier = 0;
    public override void Activate()
    {
        base.Activate();
        origMultiplier = player.GetComponent<PlayerStats>().GetDashDmgMultiplier();
        player.GetComponent<PlayerStats>().SetDashDmgMultiplier(origMultiplier*_multiplier);
    }

    public override void Deactivate()
    {
        player.GetComponent<PlayerStats>().SetDashDmgMultiplier(origMultiplier);
        Debug.Log("dash ended");
    }
}
