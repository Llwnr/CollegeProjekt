using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Invincible", menuName = "CollegeProjekt/Invincible", order = 0)]
public class Invincible : Ability
{
    public override void Activate()
    {
        base.Activate();
        player.GetComponent<Collider2D>().enabled = false;
    }

    public override void Deactivate()
    {
        player.GetComponent<Collider2D>().enabled = true;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
