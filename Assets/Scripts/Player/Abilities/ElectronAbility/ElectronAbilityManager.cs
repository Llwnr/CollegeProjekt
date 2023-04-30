using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ElectronAbilityManager : MonoBehaviour, IDashObserver
{
    private BallDash ballDash;
    [SerializeField]private ElectronAbility[] electronAbility = new ElectronAbility[Enum.GetValues(typeof(ElectronHolder.ElectronType)).Length];
    private ElectronAbility selectedElectronAbility;
    //To get the type of electron being used
    [SerializeField]private ManageElectronSelected electronSelector;
    private ElectronHolder electronHolder;

    private void Update() {
        
    }
    
    private void Awake() {
        ballDash = GetComponent<BallDash>();
        //Subscribe to ball dash to get notified when ball dashes and ends dash
        ballDash.AddDashObserver(this);
    }

    private void OnDisable() {
        ballDash.RemoveDashObserver(this);
    }

    //Activate all dash abilities when player is dashing
    public void DashStart(){
        SetSelectedElectronAbility();
        selectedElectronAbility.Activate();
    }

    //Deactivate dash abilities when player is not dashing
    public void DashEnd(){
        selectedElectronAbility.Deactivate();
    }

    void SetSelectedElectronAbility(){
        int index = (int)electronSelector.GetSelectedElectronType();
        selectedElectronAbility = electronAbility[index];
    }
}
