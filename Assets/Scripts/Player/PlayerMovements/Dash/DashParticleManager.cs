using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashParticleManager : MonoBehaviour
{
    private BallDash ballDash;
    [SerializeField]private ParticleSystem fullChargeParticle;
    [SerializeField]private List<ParticleSystem> chargingParticles = new List<ParticleSystem>();

    // Start is called before the first frame update
    void Start()
    {
        ballDash = GetComponent<BallDash>();
        StopChargingParticles();
        fullChargeParticle.Stop();
    }

    private void Update() {
        if(ballDash.IsBallCharging() || ballDash.IsBallDashing()){
            DisplayChargingParticles();
        }else{
            StopChargingParticles();
        }

        if(ballDash.IsAtMaxCharge()){
            fullChargeParticle.Play();
            SetFullChargeEmissionActive(true);
        }else{
            SetFullChargeEmissionActive(false);
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

    void SetFullChargeEmissionActive(bool value){
        var emission = fullChargeParticle.emission;
        emission.enabled = value;
    }
}

