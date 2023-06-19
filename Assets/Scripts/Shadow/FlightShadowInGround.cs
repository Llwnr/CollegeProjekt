using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightShadowInGround : MonoBehaviour
{
    private Vector3 startingPos, desiredPos;
    [SerializeField] List<Vector3> pointsToFollow = new List<Vector3>();
    private Vector3 localPosOrig;
    private float localYPosDifference;
    private Vector3 origLocalScale;

    private void Start() {
        localPosOrig = transform.localPosition;
        origLocalScale = transform.localScale;
    }

    // Update is called once per frame
    public void UpdateShadowPos(int index)
    {
        transform.position = pointsToFollow[index] + localPosOrig;
        transform.localScale = new Vector3(origLocalScale.x, (transform.parent.position.y - transform.position.y)*0.04f + origLocalScale.y,transform.localScale.z);
        index++;
        if(index >= pointsToFollow.Count) {
            index = 0;
        }
    }

    public void SetPos(Vector3 startPos, Vector3 targetPos){
        startingPos = startPos;
        desiredPos = targetPos;
        pointsToFollow = GetCurve(startingPos, desiredPos, 0, 100);
    }

    //Will return a bezier curve without height as shadow just goes a linear path
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
