using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ElectronHolder: MonoBehaviour, ISaveable
{
    [SerializeField]private int blueElectrons, redElectrons, orangeElectrons;
    [SerializeField]private Color blue, red, orange;

    SaveObject mySave;
    string mySaveJson;
    public string saveName;

    private void Awake() {
        mySave = new SaveObject();
    }

    public void Save(){
        mySave.redCount = redElectrons;
        mySave.blueCount = blueElectrons;
        mySave.orangeCount = orangeElectrons;

        mySaveJson = JsonUtility.ToJson(mySave);
        File.WriteAllText(ISaveable.baseSaveLocation + saveName, mySaveJson);
    }

    public void Load(){
        SaveObject myLoad = JsonUtility.FromJson<SaveObject>(File.ReadAllText(ISaveable.baseSaveLocation+saveName));

        redElectrons = myLoad.redCount;
        blueElectrons = myLoad.blueCount;
        orangeElectrons = myLoad.orangeCount;
    }

    public enum ElectronType{
        red,
        blue,
        orange
    }

    private void Update() {
        //SAVE AND LOAD
        // if(Input.GetKeyDown(KeyCode.S)){
        //     mySave.redCount = redElectrons;
        //     mySaveJson = JsonUtility.ToJson(mySave);
        //     File.WriteAllText(Application.dataPath + "/save.txt", mySaveJson);
        //     Debug.Log("saved");
        // }

        // if(Input.GetKeyDown(KeyCode.L)){
        //     SaveObject myLoad = JsonUtility.FromJson<SaveObject>(File.ReadAllText(Application.dataPath+"/save.txt"));
        //     redElectrons = myLoad.redCount;   
        // }
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

    private class SaveObject{
        public int redCount, blueCount, orangeCount;
    }
}
