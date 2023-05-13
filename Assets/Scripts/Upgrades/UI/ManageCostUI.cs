using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManageCostUI : MonoBehaviour
{
    [SerializeField]private GameObject electronIcon;
    
    public void SetElectronCost(ElectronHolder.ElectronType electronType, int costAmt){
        switch(electronType){
            case ElectronHolder.ElectronType.red:
                MakeElectronCostIcon(Color.red, costAmt);
                break;
            case ElectronHolder.ElectronType.orange:
                Debug.Log("making orange");
                MakeElectronCostIcon(Color.yellow, costAmt);
                break;
            case ElectronHolder.ElectronType.blue:
                MakeElectronCostIcon(Color.blue, costAmt);
                break;
            default:
                Debug.Log("No such electron type");
                break;
        }
    }

    void MakeElectronCostIcon(Color electronColor, int costAmt){
        GameObject newIcon = Instantiate(electronIcon, Vector3.zero, Quaternion.identity);
        //Set the icon to grid container
        newIcon.transform.SetParent(transform.GetChild(0), false);
        newIcon.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = costAmt.ToString();
    }
}
