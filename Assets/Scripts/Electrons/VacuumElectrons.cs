using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumElectrons : MonoBehaviour
{
    public float suckPower;
    private Transform target;
    private void OnTriggerStay2D(Collider2D other) {
        if(other.transform.CompareTag("Electron")){
            Vector2 dir = transform.position - other.transform.position;
            other.GetComponent<Rigidbody2D>().AddForce(dir*suckPower);
        }
    }

    private void Start() {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        transform.position = target.position;
    }
}
