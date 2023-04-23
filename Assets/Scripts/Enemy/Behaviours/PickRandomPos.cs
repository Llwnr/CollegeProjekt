using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class PickRandomPos : ActionNode
{
    public float rangeX, rangeY;
    public Vector3 currentPos;
    protected override void OnStart() {
        currentPos = context.transform.position;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        PickPosition();
        return State.Success;
    }

    void PickPosition(){
        float xPos = Random.Range(currentPos.x-rangeX, currentPos.x+rangeX);
        float yPos = Random.Range(currentPos.y-rangeY, currentPos.y+rangeY);
        blackboard.moveToPosition = new Vector3(xPos, yPos, currentPos.z);
    }
}
