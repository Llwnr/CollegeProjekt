using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgPopupManager : MonoBehaviour, IOnDamage
{
    [SerializeField]private GameObject textBox;
    [SerializeField]private Color32 textColor = Color.white;
    private Transform myCanvas;

    private void Awake() {
        myCanvas = GameObject.FindWithTag("DmgPopupCanvas").transform;
    }

    private void OnEnable() {
        GetComponent<BaseHealthManager>().AddObserver(this);
    }

    private void OnDisable() {
        GetComponent<BaseHealthManager>().RemoveObserver(this);
    }

    public void ActivateWhenDamaged(float dmgAmt, Transform myTransform){
        //Create new dmg popups
        GameObject newTextBox = Instantiate(textBox, myTransform.position, Quaternion.identity);
        newTextBox.GetComponent<TextMeshProUGUI>().text = dmgAmt.ToString("F0");
        newTextBox.GetComponent<TextMeshProUGUI>().color = textColor;
        newTextBox.transform.SetParent(myCanvas.transform, false);
    }

    public void ActivateWhenDamaged(string parry, Transform myTransform){
        //Create new dmg popups
        GameObject newTextBox = Instantiate(textBox, myTransform.position, Quaternion.identity);
        newTextBox.GetComponent<TextMeshProUGUI>().text = parry;
        newTextBox.GetComponent<TextMeshProUGUI>().color = Color.white;
        newTextBox.transform.SetParent(myCanvas.transform, false);
    }
    
}
