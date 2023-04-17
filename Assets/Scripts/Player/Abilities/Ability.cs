using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {
    public new string name;
    public string description;

    //Duration
    public float buffDuration;
    protected float durationTimer;
    
    //References
    protected BallDash ballDash;
    protected AbilityManager abilityManager;
    protected GameObject player;

    //Item to consume
    public Consumable.ElectronType electronToConsume;

    protected void OnEnable() {
        player = GameObject.FindWithTag("Player");
        if(player == null) return;
        ballDash = player.GetComponent<BallDash>();
        abilityManager = GameObject.FindWithTag("Player").GetComponent<AbilityManager>();
        durationTimer = buffDuration;
    }

    public virtual void OnUpdate(){
        ManageDuration();
    }

    void ManageDuration(){
        durationTimer -= Time.deltaTime;
        if(durationTimer < 0){
            Debug.Log("Removed");
            player.GetComponent<AbilityManager>().RemoveAbility(this);
        }
    }

    public virtual void Activate(){
        OnEnable();
    }
    public abstract void Deactivate();
}
