using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeTransactionManager : MonoBehaviour
{
    private ManageCostUI costManager;
    private SetUpgradeInfo upgradeInfo;
    private ElectronHolder electronHolder;
    // Start is called before the first frame update
    void Start()
    {
        costManager = transform.parent.GetComponentInChildren<ManageCostUI>();
        upgradeInfo = transform.parent.GetComponent<SetUpgradeInfo>();
        electronHolder = GameObject.FindWithTag("Player").GetComponent<ElectronHolder>();
    }

    public void ExecuteUpgrade(){
        Debug.Log("clicking on btn");
        //Check if you can satisfy the cost
        foreach(ElectronHolder.ElectronType electronType in Enum.GetValues(typeof(ElectronHolder.ElectronType))){
            if(!electronHolder.CanTakeElectron(electronType, costManager.GetCost(electronType))) {
                return;
            }
        }
        foreach(ElectronHolder.ElectronType electronType in Enum.GetValues(typeof(ElectronHolder.ElectronType))){
            for(int i=0; i<costManager.GetCost(electronType); i++){
                electronHolder.TakeElectron(electronType);
            }
        }
        //Upgrade after the costs are fulfilled
        upgradeInfo.Activate();
    }
}
