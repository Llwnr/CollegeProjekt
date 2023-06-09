using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class TrapAnticipation : ActionNode
{
    public float maxRange;
    private Vector2 pickedRange;

    //Define number of traps to make before moving on to next attack pattern
    public int numOfTraps;
    private int origNumOfTraps = 0;

    public GameObject anticipationGuide;
    protected override void OnStart()
    {
        if(origNumOfTraps < numOfTraps) origNumOfTraps = numOfTraps;

        pickedRange = Random.insideUnitCircle * maxRange + (Vector2)context.transform.position;
        blackboard.trapPosition = pickedRange;
        blackboard.trapPosition += new Vector3(0,0,5);
        //blackboard.trapPosition = pickedRange;
        //GameObject.Instantiate(anticipationGuide, pickedRange, Quaternion.identity);
    }

    protected override void OnStop()
    {
        numOfTraps--;
    }

    protected override State OnUpdate()
    {
        if(numOfTraps <= 0){
            numOfTraps = origNumOfTraps;
            return State.Failure;
        }
        return State.Success;
    }
}
