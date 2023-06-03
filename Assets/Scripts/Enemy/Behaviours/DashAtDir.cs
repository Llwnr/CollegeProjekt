using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class DashAtDir : ActionNode
{
    public float dashForce;
    public float maxDashSpeed;
    public float dashDuration;
    private float dashDurationCount;
    //For slower movement at the start
    public float warmUpDuration;
    private float warmUpDurationCount;
    public float warmUpSpeedSlower;

    private Vector2 dirToDash;
    private Rigidbody2D rb;
    protected override void OnStart() {
        dirToDash = blackboard.direction;
        ResetDuration();
        //Don't slow down when charging
        context.transform.GetComponent<StopAtSlowSpeed>().enabled = false;
        //Damage player only when charging
        context.transform.GetComponent<DamagePlayer>().SetNeutralization(false);
    }

    protected override void OnStop() {
        context.transform.GetComponent<StopAtSlowSpeed>().enabled = true;
        context.transform.GetComponent<DamagePlayer>().SetNeutralization(true);
    }

    protected override State OnUpdate() {
        //Push at the direction
        rb = context.transform.GetComponent<Rigidbody2D>();
        if(warmUpDurationCount>0){
            rb.AddForce(dirToDash*dashForce*warmUpSpeedSlower, ForceMode2D.Impulse);
        }else{
            rb.AddForce(dirToDash*dashForce, ForceMode2D.Impulse);
        }
        
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxDashSpeed);


        warmUpDurationCount -= Time.deltaTime;
        dashDurationCount -= Time.deltaTime;
        if(!(dashDurationCount <= 0)) return State.Running;
        return State.Success;
    }

    void ResetDuration(){
        dashDurationCount = dashDuration;
        warmUpDurationCount = warmUpDuration;
    }
}
