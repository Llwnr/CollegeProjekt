using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveElectrons : MonoBehaviour
{
    [SerializeField]private GameObject electron;
    [SerializeField]private int electronCount;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Player")){
            int totalElectronCount = (int)(other.transform.GetComponent<BallDash>().GetSpeed()/5f) + electronCount;
            ThrowElectrons(totalElectronCount);
        }
    }

    void ThrowElectrons(int electronCount){
        for(int i=0; i<electronCount; i++){
            Vector3 dir = Random.insideUnitCircle;
            GameObject newElectron = Instantiate(electron, transform.position+dir*4, Quaternion.identity);
        }
    }
}
