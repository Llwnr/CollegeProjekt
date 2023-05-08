using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TeleportSp", menuName = "CollegeProjekt/Abilities/TeleportSp", order = 0)]
public class TeleportSp : Ability
{
    public override void Activate()
    {
        base.Activate();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.transform.position = new Vector3(mousePos.x, mousePos.y, player.transform.position.z);
    }

    public override void Deactivate()
    {
        
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
