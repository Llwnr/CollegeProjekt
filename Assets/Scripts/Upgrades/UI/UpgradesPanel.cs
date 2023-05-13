using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesPanel : MonoBehaviour
{
    [SerializeField]private List<Upgrade> upgrades;
    [SerializeField]private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Upgrade upgrade in upgrades){
            GameObject newPanel = Instantiate(panel, Vector3.zero, Quaternion.identity);
            newPanel.transform.SetParent(transform, false);
            SetUpgradeInfo(newPanel.GetComponent<SetUpgradeInfo>(), upgrade);

            ManageCostUI costUiManager = newPanel.GetComponentInChildren<ManageCostUI>();
            //If the upgrade does not require red electrons then don't create red electrons and vice versa
            OnlySetCostlyIcons(costUiManager, upgrade);
        }
    }

    void OnlySetCostlyIcons(ManageCostUI costManager, Upgrade upgradeInfo){
        if(upgradeInfo.redElectronCost > 0){
            costManager.SetElectronCost(ElectronHolder.ElectronType.red, upgradeInfo.redElectronCost);
        }
        if(upgradeInfo.orangeElectronCost > 0){
            costManager.SetElectronCost(ElectronHolder.ElectronType.orange, upgradeInfo.orangeElectronCost);
        }
        if(upgradeInfo.blueElectronCost > 0){
            costManager.SetElectronCost(ElectronHolder.ElectronType.blue, upgradeInfo.blueElectronCost);
        }
    }

    void SetUpgradeInfo(SetUpgradeInfo upgradeBox, Upgrade upgradeInfo){
        upgradeBox.SetInfo(upgradeInfo.name, upgradeInfo.description, upgradeInfo);
    }
}
