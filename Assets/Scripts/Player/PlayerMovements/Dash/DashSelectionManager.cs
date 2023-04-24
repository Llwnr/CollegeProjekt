using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashSelectionManager : MonoBehaviour
{
    [SerializeField]private List<DashProperty> dashProperties;
    private BallDash ballDash;
    private int index = 0;

    [SerializeField]private Image dashIconHolder;

    private void Start() {
        ballDash = GetComponent<BallDash>();
        SetFirstDashType();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            ChangeDashType();
        }
    }
    
    //Change the dash type based on the list of dash properties defined in the scriptable object
    public void ChangeDashType(){
        index = (index+1)%dashProperties.Count;

        DashProperty dash = dashProperties[index];
        SetDashProperty(dash);
        SetDashIcon(dash.dashIcon);
    }

    void SetDashProperty(DashProperty dash){
        ballDash.SetDashProperty(dash.dashForce, dash.maxDashSpeed, dash.duration, dash.maxExtraSpeed, dash.maxExtraForce, dash.framesForMaxCharge, dash.dashDmgMultiplier, dash.dashAbility, dash.dashColor, dash.isPhaseThrough);
    }

    void SetFirstDashType(){
        DashProperty dash = dashProperties[0];
        SetDashProperty(dash);
        SetDashIcon(dash.dashIcon);
    }

    void SetDashIcon(Sprite sprite){
        dashIconHolder.sprite = sprite;
    }
}
