using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ElectronAbilityManager : MonoBehaviour, IDashObserver
{
    private BallDash ballDash;
    [SerializeField]private ElectronAbility[] electronAbility = new ElectronAbility[Enum.GetValues(typeof(ElectronHolder.ElectronType)).Length];
    private List<ElectronHolder.ElectronType> electronTypes = new List<ElectronHolder.ElectronType>();
    private List<ElectronAbility> activatedAbilities = new List<ElectronAbility>();
    // [SerializeField]private ElectronAbility selectedElectronAbility;
    //To get the type of electron being used
    //private ManageElectronSelected electronSelector;
    private ElectronHolder electronHolder;

    //private bool abilityActivated = false;

    private bool dontUseAbilities = false;
    
    private void Awake() {
        ballDash = GetComponent<BallDash>();
        //Subscribe to ball dash to get notified when ball dashes and ends dash
        ballDash.AddDashObserver(this);
        electronHolder = GetComponent<ElectronHolder>();
    }



    private void Start() {
        //electronSelector = GameObject.FindWithTag("ElectronManager").GetComponent<ManageElectronSelected>();

        foreach(ElectronHolder.ElectronType electronType in Enum.GetValues(typeof(ElectronHolder.ElectronType))){
            electronTypes.Add(electronType);
        }
    }

    private void Update() {
        //Disable or enable consumption of electrons for ability
        if(Input.GetKeyDown(KeyCode.R)){
            dontUseAbilities = !dontUseAbilities;
        }
        if(dontUseAbilities){
            GetComponent<SpriteRenderer>().color = new Color32(50,50,50,255);
        }else{
            GetComponent<SpriteRenderer>().color = new Color32(255,0,0,255);
        }
    }

    private void OnDisable() {
        ballDash.RemoveDashObserver(this);
    }

    //Activate all dash abilities when player is dashing
    public void DashStart(){
        // SetSelectedElectronAbility();
        // if(electronHolder.TakeElectron(electronSelector.GetSelectedElectronType())){
        //     selectedElectronAbility.Activate();
        //     abilityActivated = true;
        // }
        if(dontUseAbilities) return;
        //Activate all available electron's ability on dash
        for(int i=0; i<electronTypes.Count; i++){
            if(electronHolder.TakeElectron(electronTypes[i])){
                electronAbility[i].Activate();
                activatedAbilities.Add(electronAbility[i]);
            }
        }
        
    }

    //Deactivate dash abilities when player is not dashing
    public void DashEnd(){
        //Only deactivate if an ability was activated first
        // if(selectedElectronAbility != null && abilityActivated){
        //     selectedElectronAbility.Deactivate();
        //     abilityActivated = false;
        // }

        //Deactivate all activated abilities
        foreach(ElectronAbility ability in activatedAbilities){
            ability.Deactivate();
        }
        activatedAbilities.Clear();
    }

    void SetSelectedElectronAbility(){
        // int index = (int)electronSelector.GetSelectedElectronType();
        // selectedElectronAbility = electronAbility[index];
    }
}
