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
    private float redElectronExtraDmg;
    //Automatically consume red electron for extra damage multiplier
    private float consumedRedElectronMultiplier = 1;

    //High speed or velocity buff
    private float highSpeedBuff;

    private float dashDmgMultiplier;//Different types of dashes will have different damage multipliers

    private float finalDmg;

    private void Awake() {
        electronHolder = GetComponent<ElectronHolder>();
        playerSpeedInfo = GetComponent<SpeedInfo>();
        ballDash = GetComponent<BallDash>();
    }

    private void Update() {
        redElectronExtraDmg = electronHolder.GetMyElectronCount(Consumable.ElectronType.red);

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

    //Calculate damage after buffs and when on high speed
    //Called only when inflicting damage
    public float GetMyMaxDamage(){
        ConsumeRedElectronForMultiplier();
        //Sometimes speed limit may exceed maxSpeedLimit for a frame. In that case, use the maxSpeedLimit instead of the speed
        highSpeedBuff = 1 + (Mathf.Min(playerSpeedInfo.GetSpeed(), ballDash.GetSpeedLimit()) * 0.1f * 0.25f);
        finalDmg = (baseDmg + redElectronExtraDmg*0.8f)*highSpeedBuff*dashDmgMultiplier*consumedRedElectronMultiplier;
        return finalDmg;
    }

    void ConsumeRedElectronForMultiplier(){
        if(electronHolder.TakeElectron(Consumable.ElectronType.red)){
            consumedRedElectronMultiplier = 1.8f;
        }else{
            consumedRedElectronMultiplier = 1;
        }
    }
}
