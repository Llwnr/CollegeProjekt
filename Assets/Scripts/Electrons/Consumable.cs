using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public enum ElectronType{
        red,
        blue,
        orange
    }
    [SerializeField]private ElectronType electronType;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            other.transform.GetComponent<ElectronHolder>().AddElectron(electronType);
            gameObject.SetActive(false);
        }
    }
}
