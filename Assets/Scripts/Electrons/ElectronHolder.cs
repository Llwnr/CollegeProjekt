using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronHolder : MonoBehaviour
{
    [SerializeField]private int blueElectrons, redElectrons, orangeElectrons = 0;

    public void AddElectron(Consumable.ElectronType electronType){
        switch(electronType){
            case Consumable.ElectronType.blue:
                blueElectrons++;
                break;
            case Consumable.ElectronType.red:
                redElectrons++;
                break;
            case Consumable.ElectronType.orange:
                orangeElectrons++;
                break;
            default:
                break;
        }
    }
}
