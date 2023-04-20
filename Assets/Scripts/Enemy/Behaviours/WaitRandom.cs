using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class WaitRandom : ActionNode
{
    public float minDuration, maxDuration;
    private float duration;
    protected override void OnStart() {
        duration = Random.Range(minDuration, maxDuration);
    }

    protected override void OnStop() {

    }

    protected override State OnUpdate() {
        duration -= Time.deltaTime;
        if(duration > 0) return State.Running;
        return State.Success;
    }
}
