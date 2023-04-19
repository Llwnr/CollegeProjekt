using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class TargetPlayer : ActionNode
{
    private Transform player;
    protected override void OnStart() {
        player = GameObject.FindWithTag("Player").transform;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        Vector3 dir = (player.position - context.transform.position).normalized;
        blackboard.direction = dir;
        return State.Success;
    }
}
