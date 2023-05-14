using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgImmunityOnDash : MonoBehaviour, IDashObserver
{
    [SerializeField]private float immuneDuration;
    private float durationCount = 0;
    private HealthManager healthManager;
    private BallDash ballDash;

    private float framesForEnd = -1;

    private bool immunityActive = false;

    private void Start() {
        healthManager = GameObject.FindWithTag("Player").GetComponent<HealthManager>();
        ballDash = GetComponent<BallDash>();
        ballDash.AddDashObserver(this);
    }

    private void OnDestroy() {
        ballDash.RemoveDashObserver(this);
    }
    
    public void DashStart()
    {
        framesForEnd = 0;
        MakePlayerImmune();
    }

    public void DashEnd()
    {
    }

    void MakePlayerImmune(){
        durationCount = immuneDuration;
        healthManager.SetDmgImmunity(true);
        immunityActive = true;
    }

    private void Update() {
        if(!immunityActive) return;
        if(durationCount >= 0){
            durationCount -= Time.deltaTime;
            framesForEnd++;
        }

        if(durationCount < 0){
            healthManager.SetDmgImmunity(false);
            immunityActive = false;
            //Debug.Log("Dmg Immunity stopped : " + framesForEnd);
        }
    }

    public void IncreaseDurationBy(float amt){
        immuneDuration+=amt;
    }
}
