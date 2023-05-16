using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade : ScriptableObject {
    public new string name;
    [TextArea (3,10)]
    public string description;
    public Image icon;
    public int redElectronCost, orangeElectronCost, blueElectronCost;

    protected GameObject player;
    protected BallDash ballDash;
    protected HealthManager playerHealth;
    protected PlayerStats playerStats;

    protected void GetReferences(){
        player = GameObject.FindWithTag("Player");
        ballDash = player.GetComponent<BallDash>();
        playerHealth = player.GetComponent<HealthManager>();
        playerStats = player.GetComponent<PlayerStats>();
    }

    public abstract void Activate();
}
