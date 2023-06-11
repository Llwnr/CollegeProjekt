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

    private float offsetForTargetPlayer = 0;


    private List<GameObject> myBalls = new List<GameObject>();
    protected override void OnStart() {
        rotatorRef = GameObject.Instantiate(rotator, context.transform.position, Quaternion.identity);
        rotatorRef.GetComponent<RotateObject>().SetRotateSpeed(rotateSpeed);
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
            newBall.transform.localPosition = new Vector3(x,y,0)*distFromBall;
            //newBall.transform.SetParent(rotatorRef.transform, false);
            myBalls.Add(newBall);
        }
    }

    protected override void OnStop() {
        for(int i=0; myBalls.Count != 0;){
            GameObject.Destroy(myBalls[i]);
            myBalls.RemoveAt(i);
        }
        GameObject.Destroy(rotatorRef);
    }

    protected override State OnUpdate() {
        durationCounter -= Time.deltaTime;
        if(durationCounter < duration/2){
            for(int i=0; i<myBalls.Count; i++){
            float x, y, origX, origY;
            //Create balls at different location in perfect circle
            x = Mathf.Sin((Mathf.PI * 2 * i*360/(numOfBalls*360))/2);
            y = Mathf.Cos((Mathf.PI * 2 * i*360/(numOfBalls*360))/2);
            origX = Mathf.Sin(Mathf.PI * 2 * i*360/(numOfBalls*360));
            origY = Mathf.Cos(Mathf.PI * 2 * i*360/(numOfBalls*360));
            
            x = Mathf.Lerp(x, origX, durationCounter*4/duration);
            y = Mathf.Lerp(y, origY, durationCounter*4/duration);

            myBalls[i].transform.localPosition = new Vector3(x,y,0)*distFromBall;
        }
        }
        if(durationCounter < 0)
            return State.Success;
        else{
            return State.Running;
        }
    }
}
