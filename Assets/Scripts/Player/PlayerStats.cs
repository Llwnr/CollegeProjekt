using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]private float baseDmg;
    private SpeedInfo playerSpeedInfo;

    //Electron buffs
    private ElectronHolder electronHolder;
    private float redElectronExtraDmg;

    //High speed or velocity buff
    private float highSpeedBuff;

    private float finalDmg;

    private void Awake() {
        electronHolder = GetComponent<ElectronHolder>();
        playerSpeedInfo = GetComponent<SpeedInfo>();
    }

    private void Update() {
        redElectronExtraDmg = electronHolder.GetMyElectronCount(Consumable.ElectronType.red);
    }

    public float GetMyBaseDmg(){
        return baseDmg;
    }

    //Calculate damage after buffs and when on high speed
    public float GetMyMaxDamage(){
        highSpeedBuff = 1 + (playerSpeedInfo.GetSpeed() * 0.1f * 0.1f);
        finalDmg = (baseDmg + redElectronExtraDmg)*highSpeedBuff;
        return finalDmg;
    }
}
