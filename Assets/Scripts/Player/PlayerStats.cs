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
    private float redElectronExtraDmg;

    //High speed or velocity buff
    private float highSpeedBuff;

    private float finalDmg;

    private void Awake() {
        electronHolder = GetComponent<ElectronHolder>();
        playerSpeedInfo = GetComponent<SpeedInfo>();
        ballDash = GetComponent<BallDash>();
    }

    private void Update() {
        redElectronExtraDmg = electronHolder.GetMyElectronCount(Consumable.ElectronType.red);
    }

    public float GetMyBaseDmg(){
        return baseDmg;
    }

    //Calculate damage after buffs and when on high speed
    public float GetMyMaxDamage(){
        //Sometimes speed limit may exceed maxSpeedLimit for a frame. In that case, use the maxSpeedLimit instead of the speed
        highSpeedBuff = 1 + (Mathf.Min(playerSpeedInfo.GetSpeed(), ballDash.GetSpeedLimit()) * 0.1f * 0.25f);
        finalDmg = (baseDmg + redElectronExtraDmg)*highSpeedBuff;
        return finalDmg;
    }
}
