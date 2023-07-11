using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashParticleManager : MonoBehaviour
{
    private BallDash ballDash;
    private PlayerStats playerStats;
    [SerializeField]private GameObject fullChargeParticle;
    [SerializeField]private List<ParticleSystem> chargingParticles = new List<ParticleSystem>();
    [SerializeField]private ParticleSystem absorbedChargedParticle;

    // Start is called before the first frame update
    void Start()
    {
        ballDash = GetComponent<BallDash>();
        playerStats = GetComponent<PlayerStats>();
        StopChargingParticles();
        StopMaxChargedParticles();
    }

    private void Update() {
        if(ballDash.IsBallCharging() || ballDash.IsBallDashing()){
            DisplayChargingParticles();
        }else{
            StopChargingParticles();
        }

        if(ballDash.IsAtMaxCharge()){
            DisplayMaxChargedParticles();
        }else{
            StopMaxChargedParticles();
        }
        return;
        //Particles to manage when player parries/absorbs
        if(playerStats.GetHasParried()){
            playerStats.GetComponent<SpriteRenderer>().color = Color.white;
            absorbedChargedParticle.Play();
        }else{
            absorbedChargedParticle.Stop();
        }
    }

    //Particles to manage when dash is being charged
    void DisplayChargingParticles(){
        foreach(ParticleSystem particle in chargingParticles){
            particle.Play();
        }
    }

    void StopChargingParticles(){
        foreach(ParticleSystem particle in chargingParticles){
            particle.Stop();
        }
    }

    //Particles to manage when dash is at max charge
    void DisplayMaxChargedParticles(){
        foreach(ParticleSystem particleSystem in fullChargeParticle.GetComponentsInChildren<ParticleSystem>()){
            var emission = particleSystem.emission;
            emission.enabled = true;
        }
    }

    void StopMaxChargedParticles(){
        foreach(ParticleSystem particleSystem in fullChargeParticle.GetComponentsInChildren<ParticleSystem>()){
            var emission = particleSystem.emission;
            emission.enabled = false;
        }
    }
}

