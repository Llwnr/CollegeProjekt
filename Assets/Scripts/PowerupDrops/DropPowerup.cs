using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPowerup : MonoBehaviour
{
    [SerializeField]private GameObject dropBox;
    [SerializeField]private Ability powerup;
    private void OnDisable() {
        GameObject newDrop = Instantiate(dropBox, transform.position, Quaternion.identity);
        newDrop.GetComponent<SpriteRenderer>().sprite = powerup.abilityIcon;
        //Set the ability to give
        newDrop.GetComponent<GivePowerupOnTouch>().SetAbilityToGive(powerup);
    }
}
