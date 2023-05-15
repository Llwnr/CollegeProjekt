using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    private BallDash ballDash;
    private Rigidbody2D rb;
    private Vector2 velocityOnHit;
    [SerializeField]private float bounceDuration;
    [SerializeField]private float maxBounceSpeed;
    [SerializeField]private float bounceForce;
    private float bounceTimer;
    private bool isBouncing = false;

    [SerializeField]private float slowdownFactor;

    [Header ("Camera Shake")]
    [SerializeField]private float shakeIntensity;
    [SerializeField]private float duration;

    private void Start() {
        Application.targetFrameRate = 60;
        Debug.Log("Setting up application framerate from here");
        rb = GetComponent<Rigidbody2D>();
        ballDash = GameObject.FindWithTag("Player").GetComponent<BallDash>();
        bounceTimer = bounceDuration;
    }
    private void Update() {
        //Slowly reduce bounce velocity. Also don't let player dash for a while after impact
        if(isBouncing){
            bounceTimer -= Time.deltaTime;
            SlowdownBounceSpeed();
            DisableDash();
            EnableStun();
        }
        //Enable player to move/dash after bounce stun ends
        if(bounceTimer < 0){
            isBouncing = false;
            EnableDash();
            DisableStun();
            
        }
    }

    private void FixedUpdate() {
        velocityOnHit = rb.velocity;
    }

    void SlowdownBounceSpeed(){
        if(Mathf.Abs(rb.velocity.magnitude) > 0.1f)rb.velocity *= 1-slowdownFactor;
    }

    void DisableDash(){
        GetComponent<BallDash>().enabled = false;
    }
    void EnableDash(){
        GetComponent<BallDash>().enabled = true;
    }
    //Don't let player move for a while when colliding
    void EnableStun(){
        GetComponent<BallMovement>().enabled = false;
    }
    void DisableStun(){
        GetComponent<BallMovement>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy")){
            //Bounce
            float speed = velocityOnHit.magnitude;
            //Bounce in the correct angle and direction
            Vector2 dir = Vector2.Reflect(velocityOnHit.normalized, other.contacts[0].normal);
            rb.velocity = dir * (speed*bounceForce) + dir*3f;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxBounceSpeed);

            //How long for player to be stunned after bouncing
            float stunRatio = Mathf.Min(1, speed/ballDash.GetMaxCharge());

            StartScreenShake(speed);

            //Set bounce's max speed limit
            AddMaxSpeedLimiter();
            isBouncing = true;
            bounceTimer = bounceDuration*stunRatio;
        }
    }

    void StartScreenShake(float ballSpeed){
        //Range intensity from 0.5 to 2
        ShakeScreen(Mathf.Min(2.5f, Mathf.Max(shakeIntensity * 0.08f * ballSpeed, shakeIntensity)), Mathf.Min(0.75f, Mathf.Max(duration*ballSpeed*0.05f, duration)));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            float speed = velocityOnHit.magnitude;
            StartScreenShake(speed);
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
