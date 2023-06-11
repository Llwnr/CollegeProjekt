using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AlignOrbitBalls : ActionNode
{
    private List<GameObject> myBalls;
    public float duration;
    private float durationCounter;
    private float dist;
    protected override void OnStart() {
        myBalls = blackboard.orbitBalls;
        durationCounter = duration;
        dist = Vector2.Distance(blackboard.orbitPivot.transform.position, myBalls[0].transform.position);
        blackboard.orbitPivot.GetComponent<LookAtTarget>().enabled = true;
        blackboard.orbitPivot.GetComponent<RotateObject>().enabled = false;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        GraduallyAlignToDesiredPos();
        durationCounter -= Time.deltaTime;
        if(durationCounter < 0)
            return State.Success;
        else{
            return State.Running;
        }
    }

    void GraduallyAlignToDesiredPos(){
        for(int i=0; i<myBalls.Count; i++){
            if(!myBalls[i]){
                continue;
            }
            //Get original pos and desired pos
            float origX, origY, desiredX, desiredY;
            origX = Mathf.Sin(Mathf.PI * 2 * i*360/(myBalls.Count*360));
            origY = Mathf.Cos(Mathf.PI * 2 * i*360/(myBalls.Count*360));
            desiredX = Mathf.Sin(Mathf.PI * 2 * i*360/(myBalls.Count*360)/2);
            desiredY = Mathf.Cos(Mathf.PI * 2 * i*360/(myBalls.Count*360)/2);

            //Lerp to desired pos
            myBalls[i].transform.localPosition = Vector2.Lerp(new Vector2(desiredX, desiredY), new Vector2(origX, origY), durationCounter*2/duration) * dist;
        }
    }
}
