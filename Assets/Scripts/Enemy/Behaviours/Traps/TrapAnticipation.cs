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
        GameObject.Instantiate(anticipationGuide, pickedRange, Quaternion.identity);
    }

    protected override void OnStop()
    {
        Debug.Log("Trap at : " + pickedRange);
    }

    protected override State OnUpdate()
    {
        return State.Success;
    }
}
