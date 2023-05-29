using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorptionRangeSlowTimer : MonoBehaviour
{
    [SerializeField]private GameObject objectToBeDeactive, objectToBeActive;
    [SerializeField]private GameObject enemyToHit;
    bool canStart = false;
    private void Update() {
        //If first tutorial is deactivated and second tutorial is activated
        if(!objectToBeDeactive.activeSelf && objectToBeActive.activeSelf){
            canStart = true;
        }else{
            canStart = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!canStart) return;
        if(other.transform.CompareTag("Projectile")){
            Time.timeScale = 0.1f;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(!canStart) return;
        if(other.transform.CompareTag("Projectile")){
            Time.timeScale = 0.1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.transform.CompareTag("Projectile")){
            Time.timeScale = 1f;
        }
    }
}
