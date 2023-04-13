using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]private float maxSpeed;
    [SerializeField]private float slowDownFactor;

    private Rigidbody2D rb;

    private float hDir, vDir;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        //Get the direction to move to
        GetDirectionInput();

        SlowdownOnRelease();
    }

    void GetDirectionInput(){
        hDir = Input.GetAxis("Horizontal");
        vDir = Input.GetAxis("Vertical");
    }

    void SlowdownOnRelease(){
        //Slow ball when no input is given
        if(hDir == 0 && vDir == 0){
            rb.velocity *= slowDownFactor;
        }
    }

    private void FixedUpdate() {

        rb.AddForce(new Vector2(hDir, vDir) * moveSpeed);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
