using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Heal", menuName = "CollegeProjekt/Items/Item_Heal", order = 0)]
public class Item_Heal : ItemBase
{
    public float healAmt;
    public override void ActivateOnCollision()
    {
        base.ActivateOnCollision();
        player.GetComponent<HealthManager>().Heal(healAmt);
    }
}
