using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]private float baseDmg;
    private SpeedInfo playerSpeedInfo;
    private BallDash ballDash;

    //Electron buffs
    private ElectronHolder electronHolder;
    //Red electron increases base dmg by a little bit
    private float blueElectronExtraDmg;
    //Automatically consume red electron for extra damage multiplier
    private float consumedRedElectronMultiplier = 1;

    //High speed or velocity buff
    private float highSpeedBuff;

    [SerializeField]private float dashDmgMultiplier;//Different types of dashes will have different damage multipliers

    private float finalDmg;

    private float powerUpMultiplier = 1;

    public void SetPowerupMultiplier(float value){
        powerUpMultiplier = value;
    }

    private void Awake() {
        electronHolder = GetComponent<ElectronHolder>();
        playerSpeedInfo = GetComponent<SpeedInfo>();
        ballDash = GetComponent<BallDash>();
    }

    private void Update() {
        blueElectronExtraDmg = electronHolder.GetMyElectronCount(Consumable.ElectronType.blue);

        if(electronHolder.CanTakeElectron(Consumable.ElectronType.red)){
            //Debug.Log("Enraged");
        }
        
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
        ConsumeRedElectronForMultiplier();
        //Sometimes speed limit may exceed maxSpeedLimit for a frame. In that case, use the maxSpeedLimit instead of the speed
        highSpeedBuff = 1 + (Mathf.Min(playerSpeedInfo.GetSpeed(), ballDash.GetSpeedLimit()) * 0.1f * 0.25f);
<<<<<<< HEAD
        finalDmg = (baseDmg)*highSpeedBuff*dashDmgMultiplier;
        Debug.Log(dashDmgMultiplier);
=======
        finalDmg = (baseDmg)*highSpeedBuff*dashDmgMultiplier*consumedRedElectronMultiplier + blueElectronExtraDmg*consumedRedElectronMultiplier;
>>>>>>> parent of 2d63810 (dashAbilitySystem,Removal of 2 electrons)
        finalDmg *= powerUpMultiplier;
        return finalDmg;
    }

    void ConsumeRedElectronForMultiplier(){
        if(electronHolder.TakeElectron(Consumable.ElectronType.red)){
            consumedRedElectronMultiplier = 1.75f;
        }else{
            consumedRedElectronMultiplier = 1;
        }
    }
}
