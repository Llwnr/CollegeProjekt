using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCurve : MonoBehaviour
{
    [SerializeField]private Vector3 targetPos;
    private Vector3 currPos;
    private float height;
    private float speed;
    private float lerpValue;

    private bool hasLanded = false;

    [SerializeField]private FlightShadowInGround shadowManager;
    

    [SerializeField] List<Vector3> pointsToFollow = new List<Vector3>();

    public void Init(Vector3 targetPos, float height, float speed){
        currPos = transform.position;
        this.targetPos = targetPos;
        this.speed = speed;
        this.height = height;
        lerpValue = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(lerpValue > 1.2f) {
            hasLanded = true;
            return;
        }
        //Follow the path created by bezier curve
        transform.position = GetCurve(height, lerpValue);
        shadowManager.SetPos(currPos, targetPos, lerpValue);
        lerpValue += Time.deltaTime * speed;
    }

    //Will return a bezier curve with height;
    Vector3 GetCurve(float height, float lerpValue){
        Vector3 midPoint;
        midPoint = (currPos+targetPos)*0.5f + new Vector3(0,height,0);

        Vector3 aToMid, midToB;
        aToMid = Vector3.Lerp(currPos, midPoint, lerpValue);
        midToB = Vector3.Lerp(midPoint, targetPos, lerpValue);

        Vector3 myPoint = Vector3.Lerp(aToMid, midToB, lerpValue);

        return myPoint;
    }

    public bool HasTrapLanded(){
        return hasLanded;
    }
}
