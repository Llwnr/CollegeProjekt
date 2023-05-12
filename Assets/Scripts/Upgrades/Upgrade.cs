using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : ScriptableObject {
    public new string name;
    [TextArea (3,10)]
    public string description;

    protected GameObject player;
    protected BallDash ballDash;
    protected HealthManager playerHealth;

    protected void GetReferences(){
        player = GameObject.FindWithTag("Player");
        ballDash = player.GetComponent<BallDash>();
        playerHealth = player.GetComponent<HealthManager>();
    }

    public abstract void Activate();
}
