using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgImmunityOnDash : MonoBehaviour, IDashObserver
{
    [SerializeField]private float immuneFramesDuration;
    private float immuneFramesCount;
    private HealthManager healthManager;
    private BallDash ballDash;

    private SpriteRenderer spriteRenderer;

    private PlayerStats playerStats;

    private bool immunityActive = false;

    [SerializeField]private ParticleSystem forceField;

    private void Start() {
        healthManager = GameObject.FindWithTag("Player").GetComponent<HealthManager>();
        playerStats = GetComponent<PlayerStats>();
        ballDash = GetComponent<BallDash>();
        ballDash.AddDashObserver(this);
    }

    private void OnDestroy() {
        ballDash.RemoveDashObserver(this);
    }

    public void PlayerCollidedWithBullet(Collider2D bullet) {
        //If when player is immune to damage and parries an attack then activate the parry buff damage
        if(immunityActive && bullet.transform.CompareTag("Projectile")){
            playerStats.SetParriedOnDash();
        }
    }
    
    public void DashStart()
    {
        //forceField.Play();
        MakePlayerImmune();
    }

    public void DashEnd()
    {
    }

    void MakePlayerImmune(){
        immuneFramesCount = immuneFramesDuration;
        healthManager.SetDmgImmunity(true);
        immunityActive = true;
    }

    private void FixedUpdate() {
        if(!immunityActive) return;
        immuneFramesCount--;

        if(immuneFramesCount <= 0){
            healthManager.SetDmgImmunity(false);
            immunityActive = false;     
            //forceField.Stop();
            //Debug.Log("Dmg Immunity stopped : " + framesForEnd);
        }
    }

    public void IncreaseFrameBy(int amt){
        immuneFramesDuration+=amt;
    }
}
