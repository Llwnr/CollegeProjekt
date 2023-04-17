using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgPopupManager : MonoBehaviour, IOnDamage
{
    [SerializeField]private GameObject textBox;
    [SerializeField]private Transform myCanvas;

    private void OnEnable() {
        GetComponent<HealthManager>().AddObserver(this);
    }

    private void OnDisable() {
        GetComponent<HealthManager>().RemoveObserver(this);
    }

    public void ActivateWhenDamaged(float dmgAmt, Transform myTransform){
        //Create new dmg popups
        GameObject newTextBox = Instantiate(textBox, myTransform.position, Quaternion.identity);
        newTextBox.GetComponent<TextMeshProUGUI>().text = dmgAmt.ToString("F2");
        newTextBox.transform.SetParent(myCanvas.transform, false);
    }
    
}
