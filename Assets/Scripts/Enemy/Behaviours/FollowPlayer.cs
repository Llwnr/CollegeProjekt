using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class FollowPlayer : ActionNode
{
    private Transform myTransform;
    private Rigidbody2D rb;
    private Transform target;

    public float moveSpeed, maxSpeed;

    public float durationToNextAction;
    private float durationTimer;
    
    protected override void OnStart() {
        myTransform = context.transform;
        rb = myTransform.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        durationTimer = durationToNextAction;
    }

    protected override void OnStop() {
        rb.velocity = Vector2.zero;
    }

    protected override State OnUpdate() {
        //Follow target
        Vector3 dir = (target.position - myTransform.position).normalized;
        rb.AddForce(dir*moveSpeed, ForceMode2D.Force);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        //Go to next step when duration ends. To stop enemy from always following player and never doing anything else
        durationTimer -= Time.deltaTime;
        if(durationTimer < 0){
            return State.Success;
        }

        return State.Running;
    }
}
