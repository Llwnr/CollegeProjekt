using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveFaster", menuName = "CollegeProjekt/Abilities/MoveFaster", order = 0)]
public class MoveFaster : Ability
{
    [SerializeField]private float extraMoveSpeed;
    [SerializeField]private Gradient buffMoveColor;
    private TrailRenderer trailRenderer;

    private bool keepShowingTrail = false;
    [SerializeField]private float trailLength = 0.02f;
    private float dashEndTimer = 0;

    
    //Main function
    public override void Activate()
    {
        base.Activate();
        player.GetComponent<BallMovement>().SetExtraMoveSpeed(extraMoveSpeed);
        //Set trail color when moving with buff
        trailRenderer = player.GetComponent<TrailRenderer>();
        trailRenderer.colorGradient = buffMoveColor;
        keepShowingTrail = true;
    }

    public override void Deactivate()
    {
        player.GetComponent<BallMovement>().SetExtraMoveSpeed(0);
        //Stop trail after buff ends
        StopSpeedUpTrail();
        keepShowingTrail = false;
        player.GetComponent<BallDash>().StopDashTrails();
        Debug.Log("Deactivated");
    }

    public override void OnUpdate() {
        base.OnUpdate();
        if(keepShowingTrail && !player.GetComponent<BallDash>().IsBallDashing()){
            DisplaySpeedUpTrail();
            ManageTrailColor();
        }
        //To wait few frames before changing trail color after dashing ends
        else if(player.GetComponent<BallDash>().IsBallDashing()) dashEndTimer = 0;
    }

    IEnumerator DeactivateSoon(){
        yield return new WaitForSeconds(3);
        Deactivate();
    }

    void DisplaySpeedUpTrail(){
        trailRenderer.emitting = true;
        trailRenderer.time = trailLength;
    }

    void ManageTrailColor(){
        dashEndTimer += Time.deltaTime;
        if(dashEndTimer > 0.3f){
            trailRenderer.colorGradient = buffMoveColor;
        }
    }

    void StopSpeedUpTrail(){
        trailRenderer.emitting = false;
    }
}
