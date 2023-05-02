using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EA_DmgReduction", menuName = "CollegeProjekt/ElectronAbilities/EA_DmgReduction", order = 0)]
public class EA_DmgReduction : ElectronAbility
{
    public float dmgReductionAmt;
    public override void Activate()
    {
        base.GetReferences();
        player.GetComponent<HealthManager>().SetDmgReduction(dmgReductionAmt);
        Debug.Log("act");
    }

    public override void Deactivate()
    {
        player.GetComponent<HealthManager>().SetDmgReduction(0);
        Debug.Log("deact");
    }
}
