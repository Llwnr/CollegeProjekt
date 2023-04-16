using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 velocityOnHit;
    [SerializeField]private float bounceDuration;
    [SerializeField]private float maxBounceSpeed;
    private float bounceTimer;
    private bool isBouncing = false;

    [Header ("Camera Shake")]
    [SerializeField]private float shakeIntensity;
    [SerializeField]private float duration;

    private void Start() {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        bounceTimer = bounceDuration;
    }
    private void Update() {
        //Slowly reduce bounce velocity. Also don't let player dash for a while after impact
        if(isBouncing){
            bounceTimer -= Time.deltaTime;
            SlowdownBounceSpeed();
            DisableDash();
        }
        if(bounceTimer < 0){
            isBouncing = false;
            EnableDash();
        }
    }

    private void FixedUpdate() {
        velocityOnHit = rb.velocity;
    }

    void SlowdownBounceSpeed(){
        if(Mathf.Abs(rb.velocity.magnitude) > 0.1f)rb.velocity *= 0.82f;
    }

    void DisableDash(){
        GetComponent<BallDash>().enabled = false;
    }
    void EnableDash(){
        GetComponent<BallDash>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy")){
            //Bounce
            float speed = velocityOnHit.magnitude;
            Vector2 dir = Vector2.Reflect(velocityOnHit.normalized, other.contacts[0].normal);
            rb.velocity = dir * speed + dir*4f;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxBounceSpeed);

            ShakeScreen(Mathf.Max(shakeIntensity * 0.08f * speed, shakeIntensity), Mathf.Max(duration*speed*0.05f, duration));

            AddMaxSpeedLimiter();
            isBouncing = true;
            bounceTimer = bounceDuration;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            ShakeScreen(shakeIntensity*3f, duration*2f);
        }
    }

    void AddMaxSpeedLimiter(){
        //Don't let player be limited to base movement speed limit when bouncing
        GetComponent<LimitBallSpeed>().AddSpeedLimiter(maxBounceSpeed, bounceDuration);
    }

    void ShakeScreen(float shakeIntensity, float duration){
        CinemachineShake.instance.ShakeCamera(shakeIntensity, duration);
    }
}
