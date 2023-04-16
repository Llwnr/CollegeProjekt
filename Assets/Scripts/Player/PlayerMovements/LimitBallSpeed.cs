﻿using System.Collections;
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
    [SerializeField]private List<SpeedLimiter> speedLimiters = new List<SpeedLimiter>();
    [SerializeField]private float highestSpeed;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        ReduceDurationOfLimiters();
    }

    private void FixedUpdate() {
        ManageSpeedLimiters();
    }

    public void AddSpeedLimiter(float speedLimit, float duration){
        SpeedLimiter newLimit = new SpeedLimiter(speedLimit, duration, this);
        speedLimiters.Add(newLimit);
    }

    public void RemoveASpeedLimiter(SpeedLimiter speedLimiter){
        speedLimiters.Remove(speedLimiter);
    }

    void ReduceDurationOfLimiters(){
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

        //Also disable movement when external forces are being applied
        if(speedLimiters.Count == 0){
            GetComponent<BallMovement>().enabled = true;
        }else{
            GetComponent<BallMovement>().enabled = false;
        }
    }

    private void LateUpdate() {
        for(int i=0; i<speedLimiters.Count; i++){
            if(speedLimiters[i].RemoveWhenTimerEnds()){
                i--;
            }
        }
    }
}
