using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronHolder : MonoBehaviour
{
    [SerializeField]private int blueElectrons, redElectrons = 0;
    [SerializeField]private Color blue, red;

    public enum ElectronType{
        red,
        blue
    }

    public void AddElectron(ElectronType electronType){
        switch(electronType){
            case ElectronType.blue:
                blueElectrons++;
                break;
            case ElectronType.red:
                redElectrons++;
                break;
            default:
                break;
        }
    }

    public bool TakeElectron(ElectronType electronType){
        switch(electronType){
            case ElectronType.blue:
                if(blueElectrons > 0){
                    blueElectrons--;
                    return true;
                }
                return false;
            case ElectronType.red:
                if(redElectrons > 0){
                    redElectrons--;
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    public bool CanTakeElectron(ElectronType electronType){
        switch(electronType){
            case ElectronType.blue:
                if(blueElectrons > 0){
                    return true;
                }
                return false;
            case ElectronType.red:
                if(redElectrons > 0){
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    public int GetMyElectronCount(ElectronType electronType){
        switch(electronType){
            case ElectronType.red:
                return redElectrons;
            case ElectronType.blue:
                return blueElectrons;
            default:
                return 0;
        }
    }

    public Color GetMyElectronColor(ElectronType electronType){
        switch(electronType){
            case ElectronType.red:
                return red;
            case ElectronType.blue:
                return blue;
            default:
                return red;
        }
    }
}
