using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePowerupOnTouch : MonoBehaviour
{
    private Ability abilityToGive;

    private void OnTriggerEnter2D(Collider2D other) {
        //When player touches this powerup, activate it
        if(other.transform.CompareTag("Player")){
            other.transform.GetComponent<AbilityManager>().AddAbility(abilityToGive);
        }
    }

    public void SetAbilityToGive(Ability ability){
        abilityToGive = ability;
    }
}
