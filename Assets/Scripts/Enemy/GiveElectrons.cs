using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveElectrons : MonoBehaviour
{
    [SerializeField]private List<GameObject> electron = new List<GameObject>();
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
            int totalElectronCount = (int)(other.transform.GetComponent<SpeedInfo>().GetSpeed()/speedThreshold) + electronCount;
            ThrowElectrons(totalElectronCount);
        }
    }

    void ThrowElectrons(int electronCount){
        for(int i=0; i<electronCount; i++){
            int randomIndex = Random.Range(0, electron.Count);
            Vector3 dir = Random.insideUnitCircle;
            while(dir.magnitude < 0.4f) dir = Random.insideUnitCircle;
            GameObject newElectron = Instantiate(electron[randomIndex], transform.position+dir, Quaternion.identity);
            newElectron.GetComponent<Rigidbody2D>().AddForce(dir*4, ForceMode2D.Impulse);
            RotateElectrons.instance.AddElectronToRotate(newElectron.transform);
        }
    }
}
