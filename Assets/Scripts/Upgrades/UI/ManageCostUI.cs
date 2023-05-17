using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManageCostUI : MonoBehaviour
{
    [SerializeField]private GameObject electronIcon;
    private int redCost, orangeCost, blueCost = 0;
    
    public void SetElectronCost(ElectronHolder.ElectronType electronType, int costAmt){
        switch(electronType){
            case ElectronHolder.ElectronType.red:
                MakeElectronCostIcon(Color.red, costAmt);
                redCost = costAmt;
                break;
            case ElectronHolder.ElectronType.orange:
                MakeElectronCostIcon(Color.yellow, costAmt);
                orangeCost = costAmt;
                break;
            case ElectronHolder.ElectronType.blue:
                MakeElectronCostIcon(Color.blue, costAmt);
                blueCost = costAmt;
                break;
            default:
                Debug.Log("No such electron type");
                break;
        }
    }

    public int GetCost(ElectronHolder.ElectronType electronType){
        switch(electronType){
            case ElectronHolder.ElectronType.red:
                return redCost;
            case ElectronHolder.ElectronType.orange:
                return orangeCost;
            case ElectronHolder.ElectronType.blue:
                return blueCost;
            default:
                return 0;
        }
    }

    void MakeElectronCostIcon(Color electronColor, int costAmt){
        GameObject newIcon = Instantiate(electronIcon, Vector3.zero, Quaternion.identity);
        newIcon.GetComponent<Image>().color = electronColor;
        //Set the icon to grid container
        newIcon.transform.SetParent(transform.GetChild(0), false);
        newIcon.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = costAmt.ToString();
    }
}
