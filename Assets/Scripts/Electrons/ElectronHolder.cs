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

    public bool TakeElectron(Consumable.ElectronType electronType){
        switch(electronType){
            case Consumable.ElectronType.blue:
                if(blueElectrons > 0){
                    blueElectrons--;
                    return true;
                }
                return false;
            case Consumable.ElectronType.red:
                if(redElectrons > 0){
                    redElectrons--;
                    return true;
                }
                return false;
            case Consumable.ElectronType.orange:
                if(orangeElectrons > 0){
                    orangeElectrons--;
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    public int GetMyElectronCount(Consumable.ElectronType electronType){
        switch(electronType){
            case Consumable.ElectronType.red:
                return redElectrons;
            default:
                return 0;
        }
    }
}
