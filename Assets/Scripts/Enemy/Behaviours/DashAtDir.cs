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

    private Vector2 dirToDash;
    private Rigidbody2D rb;
    protected override void OnStart() {
        dirToDash = blackboard.direction;
        ResetDuration();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Push at the direction
        rb = context.transform.GetComponent<Rigidbody2D>();
        rb.AddForce(dirToDash*dashForce, ForceMode2D.Force);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxDashSpeed);

        dashDurationCount -= Time.deltaTime;
        if(!(dashDurationCount <= 0)) return State.Running;
        return State.Success;
    }

    void ResetDuration(){
        dashDurationCount = dashDuration;
    }
}
