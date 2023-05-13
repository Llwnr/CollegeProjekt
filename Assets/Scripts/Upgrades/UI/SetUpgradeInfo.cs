using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetUpgradeInfo : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI upgradeName, upgradeDescription;
    
    public void SetInfo(string name, string description){
        upgradeName.text = name;
        upgradeDescription.text = description;
    }
}
