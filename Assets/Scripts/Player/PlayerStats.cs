using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]private float baseDmg;
    private SpeedInfo playerSpeedInfo;
    private BallDash ballDash;

    //High speed or velocity buff
    private float highSpeedBuff;

    [SerializeField]private float dashDmgMultiplier;//Different types of dashes will have different damage multipliers

    private float finalDmg;

    private float powerUpMultiplier = 1;

    public void SetPowerupMultiplier(float value){
        powerUpMultiplier = value;
    }

    private void Awake() {
        playerSpeedInfo = GetComponent<SpeedInfo>();
        ballDash = GetComponent<BallDash>();
    }

    private void Update() {
        
    }

    public float GetMyBaseDmg(){
        return baseDmg;
    }

    public void SetDashDmgMultiplier(float multiplier){
        dashDmgMultiplier = multiplier;
    }
    public float GetDashDmgMultiplier(){
        return dashDmgMultiplier;
    }

    //Calculate damage after buffs and when on high speed
    //Called only when inflicting damage
    public float GetMyMaxDamage(){
        //Sometimes speed limit may exceed maxSpeedLimit for a frame. In that case, use the maxSpeedLimit instead of the speed
        highSpeedBuff = 1 + (Mathf.Min(playerSpeedInfo.GetSpeed(), ballDash.GetSpeedLimit()) * 0.1f * 0.25f);
        finalDmg = (baseDmg)*highSpeedBuff*dashDmgMultiplier;
        finalDmg *= powerUpMultiplier;
        return finalDmg;
    }
}
