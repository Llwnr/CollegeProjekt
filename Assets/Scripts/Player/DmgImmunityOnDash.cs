using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgImmunityOnDash : MonoBehaviour, IDashObserver
{
    [SerializeField]private float immuneDuration;
    private float durationCount = 0;
    private HealthManager healthManager;
    private BallDash ballDash;

    private void Start() {
        healthManager = GameObject.FindWithTag("Player").GetComponent<HealthManager>();
        ballDash = GetComponent<BallDash>();
        ballDash.AddDashObserver(this);
    }

    private void OnDisable() {
        ballDash.RemoveDashObserver(this);
    }
    
    public void DashStart()
    {
        MakePlayerImmune();
    }

    public void DashEnd()
    {
    }

    void MakePlayerImmune(){
        durationCount = immuneDuration;
        healthManager.SetDmgImmunity(true);
    }

    private void Update() {
        if(durationCount >= 0){
            durationCount -= Time.deltaTime;
        }

        if(durationCount < 0){
            healthManager.SetDmgImmunity(false);
        }
    }
}
