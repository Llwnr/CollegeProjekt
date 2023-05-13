using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronHolder: MonoBehaviour
{
    [SerializeField]private int blueElectrons, redElectrons, orangeElectrons;
    [SerializeField]private Color blue, red, orange;

    private bool isEnabled = false;

    private void OnEnable() {
        isEnabled = true;
    }
    private void OnDisable() {
        isEnabled = false;
    }

    public enum ElectronType{
        red,
        blue,
        orange
    }

    public void AddElectron(ElectronType electronType){
        switch(electronType){
            case ElectronType.blue:
                blueElectrons++;
                break;
            case ElectronType.red:
                redElectrons++;
                break;
            case ElectronType.orange:
                orangeElectrons++;
                break;
            default:
                break;
        }
    }

    public bool TakeElectron(ElectronType electronType){
        if(!isEnabled) return false;
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
            case ElectronType.orange:
                if(orangeElectrons > 0){
                    orangeElectrons--;
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
            case ElectronType.orange:
                if(orangeElectrons > 0){
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    public bool CanTakeElectron(ElectronType electronType, int cost){
        switch(electronType){
            case ElectronType.blue:
                if(blueElectrons-cost >= 0){
                    return true;
                }
                return false;
            case ElectronType.red:
                if(redElectrons-cost >= 0){
                    return true;
                }
                return false;
            case ElectronType.orange:
                if(orangeElectrons-cost >= 0){
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
            case ElectronType.orange:
                return orangeElectrons;
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
            case ElectronType.orange:
                return orange;
            default:
                return red;
        }
    }
}
