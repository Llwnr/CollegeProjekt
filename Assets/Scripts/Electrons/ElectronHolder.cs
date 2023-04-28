using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronHolder : MonoBehaviour
{
    [SerializeField]private int blueElectrons, redElectrons, orangeElectrons, greenElectrons = 0;
    [SerializeField]private Color blue, red, orange, green;

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
            case Consumable.ElectronType.green:
                greenElectrons++;
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
            case Consumable.ElectronType.green:
                if(greenElectrons > 0){
                    greenElectrons--;
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    public bool CanTakeElectron(Consumable.ElectronType electronType){
        switch(electronType){
            case Consumable.ElectronType.blue:
                if(blueElectrons > 0){
                    return true;
                }
                return false;
            case Consumable.ElectronType.red:
                if(redElectrons > 0){
                    return true;
                }
                return false;
            case Consumable.ElectronType.orange:
                if(orangeElectrons > 0){
                    return true;
                }
                return false;
            case Consumable.ElectronType.green:
                if(greenElectrons > 0){
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
            case Consumable.ElectronType.blue:
                return blueElectrons;
            case Consumable.ElectronType.orange:
                return orangeElectrons;
            case Consumable.ElectronType.green:
                return greenElectrons;
            default:
                return 0;
        }
    }

    public Color GetMyElectronColor(Consumable.ElectronType electronType){
        switch(electronType){
            case Consumable.ElectronType.red:
                return red;
            case Consumable.ElectronType.blue:
                return blue;
            case Consumable.ElectronType.orange:
                return orange;
            case Consumable.ElectronType.green:
                return green;
            default:
                return red;
        }
    }
}
