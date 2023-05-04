using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public new string name;
    public string desc;
    public Sprite powerupIcon;

    public float duration;
    protected float durationTimer;

    protected GameObject player;
    private PowerupsManager powerupsManager;

    protected void GetReference(){
        player = GameObject.FindWithTag("Player");
    }

    public virtual void Activate(){
        durationTimer = duration;
        GetReference();
    }

    public abstract void Deactivate();

    public virtual void OnUpdate(){

    }

    public void ReduceDuration(){
        durationTimer -= Time.deltaTime;
    }
    public void ResetDuration(){
        durationTimer = duration;
    }
    public bool HasDurationEnded(){
        return durationTimer <= 0;
    }
}
