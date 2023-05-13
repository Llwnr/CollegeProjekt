using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetUpgradeInfo : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI upgradeName, upgradeDescription;
    private Upgrade upgrade;
    
    public void SetInfo(string name, string description, Upgrade upgrade){
        upgradeName.text = name;
        upgradeDescription.text = description;
        this.upgrade = upgrade;
    }

    public void Activate(){
        upgrade.Activate();
    }


}
