using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ThrowTrap : ActionNode
{
    public GameObject trap;
    private GameObject myTrap;
    public float speed;
    public float duration;
    private float durationCount;
    protected override void OnStart() {
        durationCount = duration;
        myTrap = GameObject.Instantiate(trap, context.transform.position, Quaternion.identity);
        ThrowCurve throwCurve = myTrap.GetComponent<ThrowCurve>();
        //Initialize throw position and landing duration
        float height = Vector2.Distance(context.transform.position, blackboard.trapPosition)*0.4f;
        throwCurve.Init(blackboard.trapPosition, height+3, speed);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //myTrap.transform.position = Vector3.Lerp(myTrap.transform.position, blackboard.trapPosition, Time.deltaTime*5);

        durationCount -= Time.deltaTime;
        if(durationCount > 0){
            return State.Running;
        }
        return State.Success;
    }
}
