﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDash : MonoBehaviour
{
    [Header ("Base Dash")]
    [SerializeField]private float dashForce;
    [SerializeField]private float maxDashSpeed;
    [SerializeField]private float duration;
    private float durationTimer;

    private bool isDashing = false;

    private float hDir, vDir;
    private Vector2 dirToDash = Vector2.zero;

    [Header ("Charged Extra Dash")]
    [SerializeField]private float extraSpeed = 0;
    [SerializeField]private float extraForce = 0;
    [SerializeField]private float maxExtraSpeed, maxExtraForce;
    [SerializeField]private int framesForMaxCharge;//Number of frames taken to reach max charge

    private Color origColor;
    [SerializeField]private Color dashColor;

    private TrailRenderer dashTrail;

    private float prevFrameSpeed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTrail = GetComponent<TrailRenderer>();
        StopDashTrails();
        ResetDuration();

        origColor = GetComponent<SpriteRenderer>().color;
    }

    void ResetDuration(){
        durationTimer = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            ChargeForce();
        }
        //Dash at direction pointed by mouse
        if(Input.GetMouseButtonUp(0)){
            Dash();
            AddSpeedLimit();
            ResetExtraForcesFromCharge();
        }
        //Manage durations
        if(isDashing){
            durationTimer -= Time.deltaTime;
        }
        if(durationTimer < 0){
            ResetDuration();
            DashEnd();
        }
    }

    private void LateUpdate() {
        prevFrameSpeed = rb.velocity.magnitude;
    }

    void Dash(){
        rb.velocity = Vector2.zero;
        dirToDash = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)*10f;
        dirToDash = dirToDash.normalized;
        rb.AddForce(dirToDash*(dashForce+extraForce), ForceMode2D.Impulse);

        isDashing = true;

        DisplayDashTrails();
        SetDashColor();
    }

    void DashEnd(){
        StopDashTrails();
        DisableDashColor();
        isDashing = false;
    }

    void DisplayDashTrails(){
        dashTrail.emitting = true;
    }
    void StopDashTrails(){
        dashTrail.emitting = false;
    }

    void ChargeForce(){
        extraSpeed += maxExtraSpeed / (1+framesForMaxCharge);
        extraForce += maxExtraForce / (1+framesForMaxCharge);
        //Also limit it
        if(extraSpeed > maxExtraSpeed) extraSpeed = maxExtraSpeed;
        if(extraForce > maxExtraForce) extraForce = maxExtraForce;
    }

    void AddSpeedLimit(){
        //Give the max speed limit into clamping equation when dashing, so that it isn't capped out by base movement's 3 move speed
        GetComponent<LimitBallSpeed>().AddSpeedLimiter(maxDashSpeed+extraSpeed, duration);
    }

    void ResetExtraForcesFromCharge(){
        extraForce = 0;
        extraSpeed = 0;
    }

    public float GetSpeed(){
        return prevFrameSpeed;
    }

    public float GetMaxCharge(){
        return maxExtraSpeed;
    }
    public float GetCurrentCharge(){
        return extraSpeed;
    }

    //To change the color when dashing
    public void SetDashColor(){
        GetComponent<SpriteRenderer>().color = dashColor;
    }
    public void DisableDashColor(){
        GetComponent<SpriteRenderer>().color = origColor;
    }

    
}
