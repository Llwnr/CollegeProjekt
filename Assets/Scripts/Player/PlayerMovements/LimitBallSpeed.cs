using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBallSpeed : MonoBehaviour
{
    private Rigidbody2D rb;
    //The one with the highest speed limit is prioritized
    private float moveSpeedLimit;
    //Various speed limits from various sources
    //Movespeed may have speed limit of 8, dash may be of 40, bounce of 20 etc
    //Prioritize the highest one as long as its duration is greater than zero
    //Will limit the player's speed based on the highest speedLimit. So, even if movespeed limit is 8, if dashing, limit upto 40
    [SerializeField]private List<SpeedLimiter> speedLimiters = new List<SpeedLimiter>();
    [SerializeField]private float highestSpeed;

    [Header ("Slowdown Factor")]
    [SerializeField]private float slowdownFactor;

    private float hDir, vDir;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        ReduceDurationOfLimiters();
    }

    private void FixedUpdate() {
        ManageSpeedLimiters();
    }

    public SpeedLimiter AddSpeedLimiter(float speedLimit, float duration){
        SpeedLimiter newLimit = new SpeedLimiter(speedLimit, duration, this);
        speedLimiters.Add(newLimit);
        return newLimit;
    }

    public void RemoveASpeedLimiter(SpeedLimiter speedLimiter){
        speedLimiters.Remove(speedLimiter);
    }

    void ReduceDurationOfLimiters(){
        //Reduce duration of all the limiters based on real time.
        for(int i=0; i<speedLimiters.Count; i++){
            speedLimiters[i].ReduceDuration();
        }
    }

    private void ManageSpeedLimiters(){
        //Set the highest speed limit as default
        moveSpeedLimit = GetComponent<BallMovement>().GetNormalMoveSpeed();
        float highestLimit = moveSpeedLimit;
        for(int i=0; i<speedLimiters.Count; i++){
            if(speedLimiters[i].speedLimit > highestLimit){
                highestLimit = speedLimiters[i].speedLimit;
            }
        }
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, highestLimit);
        highestSpeed = highestLimit;

        //Only slowdown when moving normally. i.e. when there are no speed limiters(speed limit from ballmovement is just default and not included in the list)
        if(speedLimiters.Count == 0){
            SlowDownBall();
        }
    }

    void SlowDownBall(){
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
        //Slowdown ball when there's no input
        if(hDir == 0 && vDir == 0){
            rb.velocity *= 1-slowdownFactor;
        }
    }

    private void LateUpdate() {
        for(int i=0; i<speedLimiters.Count; i++){
            //Removes the speed limiter when its duration ends
            if(speedLimiters[i].RemoveWhenTimerEnds()){
                i--;
            }
        }
    }
}
