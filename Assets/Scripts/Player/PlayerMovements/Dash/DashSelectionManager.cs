using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSelectionManager : MonoBehaviour
{
    [SerializeField]private List<DashProperty> dashProperties;
    private BallDash ballDash;
    private int index = 0;

    private void Start() {
        ballDash = GetComponent<BallDash>();
        SetFirstDashType();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(1)){
            ChangeDashType();
        }
    }
    
    //Change the dash type based on the dash properties defined in the scriptable object
    public void ChangeDashType(){
        index = (index+1)%dashProperties.Count;

        DashProperty dash = dashProperties[index];
        ballDash.SetDashProperty(dash.dashForce, dash.maxDashSpeed, dash.duration, dash.maxExtraSpeed, dash.maxExtraForce, dash.framesForMaxCharge);
        
        ManageDashGoThroughObjects(dash);
    }

    void ManageDashGoThroughObjects(DashProperty dash){
        //Can the ball dash through enemies?
        if(dash.isGoThrough){
            ballDash.GetComponent<Collider2D>().isTrigger = true;
        }else{
            ballDash.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    void SetFirstDashType(){
        DashProperty dash = dashProperties[0];
        ballDash.SetDashProperty(dash.dashForce, dash.maxDashSpeed, dash.duration, dash.maxExtraSpeed, dash.maxExtraForce, dash.framesForMaxCharge);
    }
}
