using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCurve : MonoBehaviour
{
    [SerializeField]private Vector3 targetPos;
    private Vector3 currPos;

    [SerializeField]private FlightShadowInGround shadowManager;

    int index;
    [SerializeField]private float height;
    public int iterations;

    [SerializeField] List<Vector3> pointsToFollow = new List<Vector3>();

    public void Init(Vector3 targetPos, float height, int smoothness){
        currPos = transform.position;
        this.targetPos = targetPos;
        pointsToFollow = GetCurve(currPos, targetPos, height, iterations);

        //For shadow to follow based on index of this script
        this.shadowManager = transform.GetChild(0).GetComponent<FlightShadowInGround>();
        shadowManager.SetPos(currPos, targetPos);
        index = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Follow the path created by bezier curve
        transform.position = pointsToFollow[index];
        shadowManager.UpdateShadowPos(index);
        index++;
        if(index >= pointsToFollow.Count) {
            index = 0;
            pointsToFollow = GetCurve(currPos, targetPos, height, iterations);
        }
    }

    //Will return a bezier curve with height;
    List<Vector3> GetCurve(Vector3 startPos, Vector3 targetPos, float height, int numOfPoints){
        Vector3 midPoint;
        midPoint = (startPos+targetPos)*0.5f + new Vector3(0,height,0);
        Vector3 aToMid, midToB;

        List<Vector3> myPoints = new List<Vector3>();
        for(int i=0; i<numOfPoints; i++){
            aToMid = Vector3.Lerp(startPos, midPoint, i/(float)numOfPoints);
            midToB = Vector3.Lerp(midPoint, targetPos, i/(float)numOfPoints);
            Vector3 myPoint = Vector3.Lerp(aToMid, midToB, i/(float)numOfPoints);
            myPoints.Add(myPoint);
        }

        return myPoints;
    }
}
