using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyElectronType : MonoBehaviour
{
    [SerializeField]private ElectronHolder.ElectronType electronType;
    
    public void SetElectronType(ElectronHolder.ElectronType electronType){
        this.electronType = electronType;
    }

    public ElectronHolder.ElectronType GetElectronType(){
        return electronType;
    }
}
