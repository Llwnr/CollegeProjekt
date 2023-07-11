using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOnDash : MonoBehaviour
{
    private BallDash ballDash;
    // Start is called before the first frame update
    void Start()
    {
        ballDash = GetComponent<BallDash>();
    }

    private void Update() {
        if(ballDash.IsBallCharging() && !ballDash.IsAtMaxCharge()){
            CameraFocus.instance.SetZoom(true);
        }else{
            CameraFocus.instance.SetZoom(false);
        }
    }
}
