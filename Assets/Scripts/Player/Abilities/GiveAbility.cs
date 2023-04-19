using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAbility : MonoBehaviour
{
    [SerializeField]private Ability abilityToGive;
    private GameObject player;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    private void Update() {
        if(Input.GetMouseButtonDown(1)){
            //Check if the ability already exists and the electron required is satisfied
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
