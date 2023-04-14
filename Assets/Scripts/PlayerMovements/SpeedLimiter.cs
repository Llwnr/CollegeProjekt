using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimiter
{
    public float speedLimit {get; private set;}
    private float duration;
    //To remove from the array when duration ends
    private LimitBallSpeed referencedArray;
    
    public SpeedLimiter(float speedLimit, float duration, LimitBallSpeed referencedArray){
        this.speedLimit = speedLimit;
        this.duration = duration;
        this.referencedArray = referencedArray;
    }

    public void ReduceDuration() {
        duration -= Time.deltaTime;
    }

    public bool RemoveWhenTimerEnds(){
        if(duration < 0){
            referencedArray.RemoveASpeedLimiter(this);
            return true;
        }
        return false;
    }
}
