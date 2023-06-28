using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumElectrons : MonoBehaviour
{
    public float suckPower;
    private float intensity = 1;
    private Transform target;
    private void OnTriggerStay2D(Collider2D other) {
        if(other.transform.CompareTag("Electron")){
            //Just increase speed of electrons if electrons are very close
            if(Vector2.Distance(other.transform.position, transform.position) < 2f){
                intensity += 0.05f;
            }else{
                intensity = 1;
            }
            other.transform.position = Vector2.Lerp(other.transform.position, transform.position, Time.deltaTime*suckPower*intensity);
        }
    }

    private void Start() {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        transform.position = target.position;
    }
}
