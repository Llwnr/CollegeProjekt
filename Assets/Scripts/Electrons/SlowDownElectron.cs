using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownElectron : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        //Slowdown electron after released
        if(rb.velocity.magnitude > 0.01f){
            rb.velocity *= 0.975f;
        }else{
            rb.velocity = Vector2.zero;
            Destroy(this);
        }
    }
}
