using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AimPlayer : ActionNode
{
    public float duration;
    private float durationCount;

    private Transform player, myTransform;
    protected override void OnStart() {
        durationCount = duration;
        player = GameObject.FindWithTag("Player").transform;
        myTransform = context.transform;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Rotate z axis to look at player
        Vector2 targetPos = player.position - myTransform.position;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        myTransform.eulerAngles = new Vector3(0,0, angle-90);

        durationCount -= Time.deltaTime;
        if(durationCount > 0) return State.Running;
        return State.Success;
    }
}
