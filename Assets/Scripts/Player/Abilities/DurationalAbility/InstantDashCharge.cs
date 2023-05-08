using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InstantDashCharge", menuName = "CollegeProjekt/Abilities/InstantDashCharge", order = 0)]
public class InstantDashCharge : Ability
{
    public override void Activate()
    {
        base.Activate();   
    }

    public override void Deactivate()
    {
        
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        ballDash.SetChargeToMax();
    }
    
    public override bool CanActivate()
    {
        //Check if all electrons are available for consumption
        foreach(ElectronHolder.ElectronType electronType in System.Enum.GetValues(typeof(ElectronHolder.ElectronType))){
            if(!electronHolder.CanTakeElectron(electronType)){
                Debug.Log("Can't take electron. RIP ability");
                return false;
            }
        }
        //If you can take one electron of each type, then take it and activate ability
        foreach(ElectronHolder.ElectronType electronType in System.Enum.GetValues(typeof(ElectronHolder.ElectronType))){
            electronHolder.TakeElectron(electronType);
        }
        return true;
    }
}
