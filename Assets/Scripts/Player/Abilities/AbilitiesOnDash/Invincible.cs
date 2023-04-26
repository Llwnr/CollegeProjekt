using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Invincible", menuName = "CollegeProjekt/Abilities/Invincible", order = 0)]
public class Invincible : DashAbility
{
    public override void Activate()
    {
        base.GetReferences();
        player.GetComponent<HealthManager>().SetInvincible(true);
        Debug.Log("Player is invincible");
    }

    public override void Deactivate()
    {
        player.GetComponent<HealthManager>().SetInvincible(false);
        Debug.Log("Player stopped invincibility");
    }
}
