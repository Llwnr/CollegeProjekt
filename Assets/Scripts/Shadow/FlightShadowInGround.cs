using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightShadowInGround : MonoBehaviour
{
    private Vector3 localPosOrig;
    private Vector3 origLocalScale;

    private void Start() {
        localPosOrig = transform.localPosition;
        origLocalScale = transform.localScale;
    }

    public void SetPos(Vector3 startPos, Vector3 targetPos, float lerpValue){
        Vector3 midPoint;
        midPoint = (startPos+targetPos)*0.5f + new Vector3(0,0,0);
        Vector3 aToMid, midToB;

        aToMid = Vector3.Lerp(startPos, midPoint, lerpValue);
        midToB = Vector3.Lerp(midPoint, targetPos, lerpValue);
        Vector3 myPoint = Vector3.Lerp(aToMid, midToB, lerpValue);
        transform.position = myPoint + localPosOrig;
        if(lerpValue >= 1){
            transform.localPosition = localPosOrig;
        }
    }
}
