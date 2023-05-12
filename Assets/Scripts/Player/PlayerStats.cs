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
    private float maxChargeBuff;

    [SerializeField]private float dashDmgMultiplier;//Different types of dashes will have different damage multipliers

    [SerializeField]private float redElectronMultiplier = 0;

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
    public void SetRedElectronMultiplier(float amt){
        redElectronMultiplier = amt;
    }

    //Calculate damage after buffs and when on high speed
    //Called only when inflicting damage
    public float GetMyMaxDamage(){
        if(ballDash.IsAtMaxCharge()){
            maxChargeBuff = 8;
        }else{
            maxChargeBuff = 0;
        }
        //Sometimes speed limit may exceed maxSpeedLimit for a frame. In that case, use the maxSpeedLimit instead of the speed
        highSpeedBuff = 1 + (Mathf.Min(playerSpeedInfo.GetSpeed(), ballDash.GetSpeedLimit()) * 0.1f * 0.5f);
        Debug.Log("High speed: " + highSpeedBuff);
        finalDmg = (baseDmg)+highSpeedBuff*dashDmgMultiplier;
        finalDmg += maxChargeBuff;
        finalDmg *= powerUpMultiplier*(1+redElectronMultiplier);
        if(finalDmg < 0) finalDmg = 0;
        Debug.Log("final dmg: " + finalDmg);
        return finalDmg;
    }
}
