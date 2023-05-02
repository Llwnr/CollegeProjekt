using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsManager : MonoBehaviour
{
    private GameObject player;
    private List<Powerup> powerups = new List<Powerup>();
    private void Awake() {
        player = GameObject.FindWithTag("Player");
        AddPowerup(powerup1);
    }

    public Powerup powerup1;
    
    public void AddPowerup(Powerup powerup){
        //Add a powerup and activate it also
        powerups.Add(powerup);
        powerup.Activate();
    }

    public void RemovePowerup(Powerup powerup){
        //Deactivate the powerup then remove it from list
        powerup.Deactivate();
        powerups.Remove(powerup);
    }

    private void Update() {
        ManagePowerupsDuration();
    }

    private void LateUpdate() {
        RemovePowerupsOnDurationEnd();
    }

    void ManagePowerupsDuration(){
        foreach(Powerup powerup in powerups){
            powerup.ReduceDuration();
        }
    }

    void RemovePowerupsOnDurationEnd(){
        for(int i=0; i<powerups.Count; i++){
            if(powerups[i].HasDurationEnded()){
                RemovePowerup(powerups[i]);
                i--;
            }
        }
    }
}
