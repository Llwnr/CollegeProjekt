using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField]private float inconsumableDuration;
    public enum ElectronType{
        red,
        blue,
        orange,
        green
    }
    [SerializeField]private ElectronType electronType;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            other.transform.GetComponent<ElectronHolder>().AddElectron(electronType);
            gameObject.SetActive(false);
        }
    }

    private void Awake() {
        DisableBeingConsumed();
    }

    void DisableBeingConsumed(){
        //Don't let player consume electrons right away
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(EnableBeingConsumed());
    }

    IEnumerator EnableBeingConsumed(){
        yield return new WaitForSeconds(inconsumableDuration);
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnDestroy() {
        //Activate electron functions when consumed
        if(electronType == ElectronType.green){
            GameObject.FindWithTag("Player").GetComponent<HealthManager>().Heal(10);
        }
    }



}
