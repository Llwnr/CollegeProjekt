using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAbility : MonoBehaviour
{
    [SerializeField]private Ability abilityToGive;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.N)){
            GiveMyAbility(GameObject.FindWithTag("Player"));
        }
    }

    private void GiveMyAbility(GameObject player){
        player.GetComponent<AbilityManager>().AddAbility(abilityToGive);
    }
}
