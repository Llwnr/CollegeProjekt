using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AnticipationShake : ActionNode
{
    private Transform myTransform;
    private Vector2 origPos;

    public float shakeIntensity;

    public float shakeDuration;
    private float shakeDurationTimer;

    protected override void OnStart() {
        myTransform = context.transform;
        origPos = myTransform.position;
        ResetShakeDuration();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        ShakeTransform();

        shakeDurationTimer -= Time.deltaTime;
        //Stop running once duration ends
        if(shakeDurationTimer < 0) return State.Success;
        else return State.Running;
    }

    void ShakeTransform(){
        myTransform.position = origPos + Random.insideUnitCircle * shakeIntensity;
    }

    void ResetShakeDuration(){
        shakeDurationTimer = shakeDuration;
    }
}
