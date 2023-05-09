using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDash : MonoBehaviour
{
    //OBSERVER PATTERN. DashAbilityManager is subscribed. Used to notify dash start and dash end
    private List<IDashObserver> dashObservers = new List<IDashObserver>();
    public void AddDashObserver(IDashObserver dashObserver){
        dashObservers.Add(dashObserver);
    }
    public void RemoveDashObserver(IDashObserver dashObserver){
        dashObservers.Remove(dashObserver);
    }
    public void NotifyDashStart(){
        foreach(IDashObserver dashObserver in dashObservers){
            dashObserver.DashStart();
        }
    }
    public void NotifyDashEnd(){
        foreach(IDashObserver dashObserver in dashObservers){
            dashObserver.DashEnd();
        }
    }

    [Header ("Base Dash")]
    [SerializeField]private float dashForce;
    [SerializeField]private float maxDashSpeed;
    [SerializeField]private float duration;
    [SerializeField]private float durationTimer;

    private bool isDashing = false;

    private float hDir, vDir;
    private Vector2 dirToDash = Vector2.zero;

    [Header ("Charged Extra Dash")]
    [SerializeField]private float extraSpeed = 0;
    [SerializeField]private float extraForce = 0;
    [SerializeField]private float maxExtraSpeed, maxExtraForce;
    [SerializeField]private int framesForMaxCharge;//Number of frames taken to reach max charge
    [SerializeField]private float chargeSpeed;//So that player can be buffed for faster charges
    private bool isPhaseThrough;//Can the dash go through enemies

    //For dash ability
    //Ability is durational while dash ability is only when dashing
    private Ability abilityToGive;
    [SerializeField]private Collider2D phaseCollider;

    //For limiting ball speed to not exceed dash speed
    private SpeedLimiter speedLimiter;

    public Ability GetDurationalAbility(){
        return abilityToGive;
    }

    private Color origColor;
    [SerializeField]private Color dashColor;

    private TrailRenderer dashTrail;
    private Gradient dashTrailColor;
    private float origDashLength;

    //Animation manager
    private Animator animator;

    private Rigidbody2D rb;

    //To allow different types of dashes
    public void SetDashProperty(float dashForce, float maxDashSpeed, float duration, float maxExtraSpeed, float maxExtraForce, int framesForMaxCharge, float dashDmgMultiplier, Ability ability, Gradient dashColor, bool isPhaseThrough){
        this.dashForce = dashForce;
        this.maxDashSpeed = maxDashSpeed;
        this.duration = duration;
        this.maxExtraSpeed = maxExtraSpeed;
        this.maxExtraForce = maxExtraForce;
        this.framesForMaxCharge = framesForMaxCharge;
        this.abilityToGive = ability;
        this.dashTrailColor = dashColor;
        this.isPhaseThrough = isPhaseThrough;
        //Give the dash's dmg multiplier to player stats for damage calculation
        GetComponent<PlayerStats>().SetDashDmgMultiplier(dashDmgMultiplier);
    }
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTrail = GetComponent<TrailRenderer>();
        phaseCollider.enabled = false;
        StopDashTrails();
        ResetDuration();

        origColor = GetComponent<SpriteRenderer>().color;
        origDashLength = dashTrail.time;

        animator = GetComponent<Animator>();
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
            NotifyDashStart();
            AddSpeedLimit();
        }
        //Manage durations
        if(isDashing){
            durationTimer -= Time.deltaTime;
        }
        if(durationTimer < 0){
            ResetDuration();
            DashEnd();
        }
        //Manage phase through
        if(isPhaseThrough && isDashing){
            PhaseBall();
        }
    }

    void Dash(){
        Time.timeScale = 0.1f;
        //Limit to maximum values incase maximum values change when dash property changes
        ChargeForce();

        rb.velocity = Vector2.zero;
        dirToDash = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)*10f;
        dirToDash = dirToDash.normalized;
        rb.AddForce(dirToDash*(dashForce+extraForce), ForceMode2D.Impulse);

        isDashing = true;
        ResetDuration();

        DisplayDashTrails();
        //SetDashColor();
        animator.Play("DashStart");
    }

    public void DashEnd(){
        StopDashTrails();
        DisableDashColor();
        isDashing = false;
        animator.Play("DashEnd");
        //Incase ball can go through enemies
        StopPhase();
        NotifyDashEnd();
        RemoveASpeedLimiter();
        ResetExtraForcesFromCharge();
    }

    void PhaseBall(){
        gameObject.layer = LayerMask.NameToLayer("PhaseThrough");
        phaseCollider.enabled = true;
    }

    void StopPhase(){
        gameObject.layer = LayerMask.NameToLayer("Player");
        phaseCollider.enabled = false;
    }



    public void DisplayDashTrails(){
        dashTrail.colorGradient = dashTrailColor;
        dashTrail.time = origDashLength;
        dashTrail.emitting = true;
    }
    public void StopDashTrails(){
        dashTrail.emitting = false;
    }

    public void ChargeForce(){
        float totalFramesToTake = 1+framesForMaxCharge/chargeSpeed;
        extraSpeed += maxExtraSpeed / totalFramesToTake;
        extraForce += maxExtraForce / totalFramesToTake;
        //Also limit it
        if(extraSpeed > maxExtraSpeed) extraSpeed = maxExtraSpeed;
        if(extraForce > maxExtraForce) extraForce = maxExtraForce;
    }

    void AddSpeedLimit(){
        //Give the max speed limit into clamping equation when dashing, so that it isn't capped out by base movement's move speed
        speedLimiter = GetComponent<LimitBallSpeed>().AddSpeedLimiter(GetSpeedLimit(), durationTimer);
    }

    void RemoveASpeedLimiter(){
        if(speedLimiter != null)
        GetComponent<LimitBallSpeed>().RemoveASpeedLimiter(speedLimiter);
    }

    public float GetSpeedLimit(){
        //Get maximum dash speed limit
        return maxDashSpeed+maxExtraSpeed;
    }

    void ResetExtraForcesFromCharge(){
        extraForce = 0;
        extraSpeed = 0;
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

    public bool IsBallDashing(){
        return isDashing;
    }
    public bool IsAtMaxCharge(){
        if(maxExtraSpeed == extraSpeed) return true;
        return false;
    }

    //BUFFS ARE HERE:
    //INSTANT CHARGE
    public void SetChargeToMax(){
        extraSpeed = maxExtraSpeed;
        extraForce = maxExtraForce;
    }
    //Increase dash duration
    public void IncreaseDashDuration(float byAmt){
        durationTimer += byAmt;
    }

    
}
