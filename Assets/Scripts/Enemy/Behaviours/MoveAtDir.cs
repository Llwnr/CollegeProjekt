using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class MoveAtDir : ActionNode
{
    private Transform myTransform;
    private Rigidbody2D rb;

    public float moveSpeed, maxSpeed;

    public float duration;
    private float durationTimer;

    private Vector2 dir;
    protected override void OnStart() {
        myTransform = context.transform;
        rb = myTransform.GetComponent<Rigidbody2D>();
        rb.WakeUp();
        dir = (blackboard.moveToPosition - myTransform.position).normalized;
        durationTimer = duration;
    }

    protected override void OnStop() {
        rb.velocity = Vector2.zero;
        rb.Sleep();
    }

    protected override State OnUpdate() {
        durationTimer -= Time.deltaTime;
        if(durationTimer < 0){
            return State.Success;
        }
        rb.AddForce(dir*moveSpeed, ForceMode2D.Force);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        return State.Running;
    }
}
