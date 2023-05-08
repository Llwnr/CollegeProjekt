using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Item_ElectronPack", menuName = "CollegeProjekt/Items/Item_ElectronPack", order = 0)]
public class Item_ElectronPack : ItemBase
{
    public int numOfElectrons;
    public override void ActivateOnCollision()
    {
        base.ActivateOnCollision();
        //Adds electrons
        for(int i=0; i<numOfElectrons; i++){
            foreach(ElectronHolder.ElectronType electronType in Enum.GetValues(typeof(ElectronHolder.ElectronType))){
                player.GetComponent<ElectronHolder>().AddElectron(electronType);
            }
        }
    }
}
