using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDashObserver
{
    [SerializeField]private float baseDmg;
    private SpeedInfo playerSpeedInfo;
    private BallDash ballDash;

    //High speed or velocity buff
    private float highSpeedBuff;
    [SerializeField]private float maxChargeBuff;

    //Dash parry buff
    [SerializeField]private float dashParryBuff = 1;
    private bool hasParried = false;

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
        ballDash.AddDashObserver(this);
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
        float chargeBuff = 0;
        if(ballDash.IsAtMaxCharge()){
            chargeBuff = maxChargeBuff;
        }
        float parryBuff = (hasParried ? dashParryBuff : 0) + 1;
        //Sometimes speed limit may exceed maxSpeedLimit for a frame. In that case, use the maxSpeedLimit instead of the speed
        highSpeedBuff = 1+(Mathf.Min(ballDash.GetTotalCurrSpeed(), ballDash.GetSpeedLimit()) * 0.05f);
        finalDmg = (baseDmg)+chargeBuff;
        finalDmg *= highSpeedBuff;
        finalDmg *= powerUpMultiplier*(1+redElectronMultiplier)*(parryBuff)*dashDmgMultiplier;
        if(finalDmg < 0) finalDmg = 0;

        
        GetComponent<SpriteRenderer>().color = new Color32(255,0,0,255);
        return finalDmg;
    }

    public void DashStart()
    {
    }

    public void DashEnd()
    {
        //Reset parry status when dash ends
        Time.timeScale = 1;
        //Reset absorbed buff
        hasParried = false;
    }

    public void SetParriedOnDash(){
        hasParried = true;
    }

    public bool GetHasParried(){
        return hasParried;
    }

    public void IncreaseParryDmg(float byAmt){
        dashParryBuff += byAmt;
    }
}
