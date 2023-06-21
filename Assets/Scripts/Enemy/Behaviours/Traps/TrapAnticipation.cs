using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class TrapAnticipation : ActionNode
{
    public float maxRange;
    private Vector2 pickedRange;

    public GameObject anticipationGuide;
    protected override void OnStart()
    {
        pickedRange = Random.insideUnitCircle * maxRange + (Vector2)context.transform.position;
        blackboard.trapPosition = GameObject.FindWithTag("Player").transform.position + new Vector3(0,0,5);
        //blackboard.trapPosition = pickedRange;
        //GameObject.Instantiate(anticipationGuide, pickedRange, Quaternion.identity);
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        return State.Success;
    }
}
