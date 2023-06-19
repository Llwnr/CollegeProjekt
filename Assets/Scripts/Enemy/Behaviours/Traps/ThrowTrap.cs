using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ThrowTrap : ActionNode
{
    public GameObject trap;
    private GameObject myTrap;
    public float duration;
    private float durationCount;
    protected override void OnStart() {
        durationCount = duration;
        myTrap = GameObject.Instantiate(trap, context.transform.position, Quaternion.identity);
        ThrowCurve throwCurve = myTrap.GetComponent<ThrowCurve>();
        throwCurve.Init(blackboard.trapPosition, 5, (int)(duration/Time.deltaTime));
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
