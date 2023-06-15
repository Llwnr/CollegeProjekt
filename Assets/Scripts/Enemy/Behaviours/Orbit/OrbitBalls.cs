using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class OrbitBalls : ActionNode
{
    public GameObject ball;
    public GameObject rotator;
    private GameObject rotatorRef;
    public int numOfBalls;
    public float distFromBall;
    public float duration;
    private float durationCounter;

    public float rotateSpeed;
    private float newAngle = 0;

    private Transform myTransform, player;

    public float pivotFollowSpeed;


    private List<GameObject> myBalls = new List<GameObject>();
    protected override void OnStart() {
        player = GameObject.FindWithTag("Player").transform;
        myTransform = context.transform;
        rotatorRef = GameObject.Instantiate(rotator, context.transform.position, Quaternion.identity);
        rotatorRef.GetComponent<RotateObject>().SetRotateSpeed(rotateSpeed);
        //Make sure pivot position is the same as my transform
        rotatorRef.GetComponent<FollowObject>().SetTarget(myTransform);
        rotatorRef.GetComponent<FollowObject>().SetLerpSpeed(pivotFollowSpeed);
        blackboard.orbitPivot = rotatorRef;
        CreateBalls();

        durationCounter = duration;
        newAngle = 0;
    }

    void CreateBalls(){
        for(int i=0; i<numOfBalls; i++){
            float x, y;
            //Create balls at different location in perfect circle
            x = Mathf.Sin(Mathf.PI * 2 * i*360/(numOfBalls*360));
            y = Mathf.Cos(Mathf.PI * 2 * i*360/(numOfBalls*360));
        

            GameObject newBall = GameObject.Instantiate(ball,rotatorRef.transform.position, Quaternion.identity);
            newBall.transform.localPosition = new Vector3(x,y,0);
            newBall.transform.SetParent(rotatorRef.transform, false);
            myBalls.Add(newBall);
            blackboard.orbitBalls.Add(newBall);
        }
    }

    protected override void OnStop() {
        
    }

    protected override State OnUpdate() {
        durationCounter -= Time.deltaTime;
        GraduallyExpandToMaxDist();
        if(durationCounter < 0)
            return State.Success;
        else{
            return State.Running;
        }
    }

    void GraduallyExpandToMaxDist(){
        for(int i=0; i<myBalls.Count; i++){
            if(!myBalls[i]){
                continue;
            }
            float origX, origY;
            origX = Mathf.Sin(Mathf.PI * 2 * i*360/(numOfBalls*360));
            origY = Mathf.Cos(Mathf.PI * 2 * i*360/(numOfBalls*360));
            myBalls[i].transform.localPosition = new Vector3(origX, origY, 0) * Mathf.Lerp(distFromBall, 1, durationCounter/duration);
        }
    }
}
