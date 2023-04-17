using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgPopup : MonoBehaviour, IOnDamage
{
    [SerializeField]private TextMeshProUGUI textBox;

    private void OnEnable() {
        GetComponent<HealthManager>().AddObserver(this);
    }

    private void OnDisable() {
        GetComponent<HealthManager>().RemoveObserver(this);
    }

    public void ActivateWhenDamaged(float dmgAmt){
        
        textBox.text = dmgAmt.ToString();
    }
    
}
