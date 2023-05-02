using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePowerupOnTouch : MonoBehaviour
{
    private Powerup powerupToGive;

    private void OnTriggerEnter2D(Collider2D other) {
        //When player touches this powerup, activate it
        if(other.transform.CompareTag("Player")){
            PowerupsManager.instance.AddPowerup(powerupToGive);
        }
    }

    public void SetAbilityToGive(Powerup powerup){
        powerupToGive = powerup;
    }
}
