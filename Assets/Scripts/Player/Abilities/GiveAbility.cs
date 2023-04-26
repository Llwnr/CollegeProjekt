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
            abilityToGive = ballDash.GetDashAbility();
            //Check if the ability already exists
            AbilityManager abilityManager = player.GetComponent<AbilityManager>();
            if(!abilityManager.GetMyAbilities().Contains(abilityToGive)){
                Debug.Log("Ability Given");
                GiveMyAbility(player);
            }
        }
    }

    private void GiveMyAbility(GameObject player){
        player.GetComponent<AbilityManager>().AddAbility(abilityToGive);
    }
}
