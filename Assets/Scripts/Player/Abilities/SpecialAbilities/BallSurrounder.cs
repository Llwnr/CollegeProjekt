using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallSurrounder", menuName = "CollegeProjekt/Abilities/BallSurrounder", order = 0)]
public class BallSurrounder : Ability
{
    public GameObject objectToMake;
    private GameObject createdObject = null;
    public override void Activate()
    {
        base.Activate();
        if(createdObject != null){
            createdObject.gameObject.SetActive(true);
            createdObject.transform.position = player.transform.position;
            return;
        }
        //Glow player
        createdObject = Instantiate(objectToMake, player.transform.position, Quaternion.identity);
        createdObject.GetComponent<FollowObject>().SetTarget(player.transform);
    }

    public override void Deactivate()
    {
        createdObject.SetActive(false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
    
    public override bool CanActivate()
    {
        base.Activate();
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
