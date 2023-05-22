using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManagePassivesOfElectrons : MonoBehaviour
{
    private ElectronHolder electronHolder;
    [SerializeField]private int redCount, blueCount, orangeCount;
    private PlayerStats playerStats;
    private BallDash ballDash;
    private int currCount;
    // Start is called before the first frame update
    void Start()
    {
        electronHolder = GetComponent<ElectronHolder>();
        playerStats = GetComponent<PlayerStats>();
        ballDash = GetComponent<BallDash>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(ElectronHolder.ElectronType electronType in Enum.GetValues(typeof(ElectronHolder.ElectronType))){
            currCount = electronHolder.GetMyElectronCount(electronType);
            //If the number of electron you're holding didn't change then dont do anything
            switch(electronType){
                case ElectronHolder.ElectronType.red:
                    if(currCount == redCount) continue;
                    break;
                case ElectronHolder.ElectronType.blue:
                    if(currCount == blueCount) continue;
                    break;
                case ElectronHolder.ElectronType.orange:
                    if(currCount == orangeCount) continue;
                    break;
                default: break;
            }
            SetElectronPassive(electronType);
        }
    }

    private void SetElectronPassive(ElectronHolder.ElectronType electronType){     
        switch(electronType){
            case ElectronHolder.ElectronType.red:
                redCount = currCount;
                playerStats.SetRedElectronMultiplier(redCount/40f);
                break;
            case ElectronHolder.ElectronType.blue:
                blueCount = currCount;
                ballDash.SetChargeFrameReduction((int)blueCount/7);
                break;
            case ElectronHolder.ElectronType.orange:
                orangeCount = currCount;
                playerStats.GetComponent<HealthManager>().SetDmgReduction((int)orangeCount/15);
                break;
            default: break;
        }
    }
}
