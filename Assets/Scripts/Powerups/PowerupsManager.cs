using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsManager : MonoBehaviour
{
    public static PowerupsManager instance{get; private set;}
    [SerializeField]private List<Powerup> powerups = new List<Powerup>();
    private void Awake() {
        if(instance != null){
            Debug.LogError("More than two powerupmanager instances");
        }else{
            instance = this;
        }
    }
    
    public void AddPowerup(Powerup powerup){
        //Only add unique powerups, otherwise just reset duration
        if(powerups.Contains(powerup)){
            int index = powerups.IndexOf(powerup);
            powerups[index].ResetDuration();
        }else{
            //Add a powerup and activate it also
            powerups.Add(powerup);
            powerup.Activate();
        }
        
    }

    public void RemovePowerup(Powerup powerup){
        //Deactivate the powerup then remove it from list
        powerup.Deactivate();
        powerups.Remove(powerup);
    }

    private void Update() {
        ManagePowerupsDuration();
        ExecuteUpdateActionOfPowerups();
    }

    private void LateUpdate() {
        RemovePowerupsOnDurationEnd();
    }

    void ManagePowerupsDuration(){
        foreach(Powerup powerup in powerups){
            powerup.ReduceDuration();
        }
    }

    void ExecuteUpdateActionOfPowerups(){
        foreach(Powerup powerup in powerups){
            powerup.OnUpdate();
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
