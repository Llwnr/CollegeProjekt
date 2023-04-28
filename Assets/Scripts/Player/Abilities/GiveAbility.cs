using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAbility : MonoBehaviour
{
    private Ability abilityToGive;
    [SerializeField]private BallDash ballDash;
    private GameObject player;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    private void Update() {
        if(Input.GetMouseButtonDown(1)){
            //Get the ability of dash
<<<<<<< HEAD
            abilityToGive = ballDash.GetDurationalAbility();
            //Check if the ability already exists
=======
            abilityToGive = ballDash.GetDashAbility();
            //Check if the ability already exists and the electron required is satisfied
>>>>>>> parent of 2d63810 (dashAbilitySystem,Removal of 2 electrons)
            AbilityManager abilityManager = player.GetComponent<AbilityManager>();
            if(!abilityManager.GetMyAbilities().Contains(abilityToGive) && player.GetComponent<ElectronHolder>().TakeElectron(abilityToGive.electronToConsume)){
                Debug.Log("Ability Given");
                GiveMyAbility(player);
            }
            
        }
    }

    private void GiveMyAbility(GameObject player){
        player.GetComponent<AbilityManager>().AddAbility(abilityToGive);
    }
}
