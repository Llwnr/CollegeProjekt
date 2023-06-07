using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashParticleManager : MonoBehaviour
{
    private BallDash ballDash;
    [SerializeField]private GameObject fullChargeParticle;
    [SerializeField]private List<ParticleSystem> chargingParticles = new List<ParticleSystem>();

    // Start is called before the first frame update
    void Start()
    {
        ballDash = GetComponent<BallDash>();
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
    }

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

