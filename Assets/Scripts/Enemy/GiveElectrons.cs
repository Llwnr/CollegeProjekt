using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveElectrons : MonoBehaviour
{
    [SerializeField]private GameObject electron;
    [SerializeField]private int electronCount;

    [SerializeField]private float speedThreshold;
    
    private void OnCollisionEnter2D(Collision2D other) {
        ManageElectronGeneration(other.transform);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        ManageElectronGeneration(other.transform);
    }

    void ManageElectronGeneration(Transform other){
        if(other.CompareTag("Player")){
            int totalElectronCount = (int)(other.transform.GetComponent<BallDash>().GetSpeed()/speedThreshold) + electronCount;
            ThrowElectrons(totalElectronCount);
        }
    }

    void ThrowElectrons(int electronCount){
        for(int i=0; i<electronCount; i++){
            Vector3 dir = Random.insideUnitCircle;
            while(dir.magnitude < 0.4f) dir = Random.insideUnitCircle;
            GameObject newElectron = Instantiate(electron, transform.position+dir*3, Quaternion.identity);
            GetComponent<RotateElectrons>().AddElectronToRotate(newElectron.transform);
        }
    }
}
