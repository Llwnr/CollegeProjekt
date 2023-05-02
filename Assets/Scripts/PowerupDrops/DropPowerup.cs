using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPowerup : MonoBehaviour, IOnDeath
{
    [SerializeField]private GameObject dropBox;
    [SerializeField]private Powerup powerup;
    private HealthManager healthManager;
    private void Start() {
        healthManager = GetComponent<HealthManager>();
        healthManager.AddObserver(this);
    }
    public void OnDeath() {
        GameObject newDrop = Instantiate(dropBox, transform.position, Quaternion.identity);
        newDrop.GetComponent<SpriteRenderer>().sprite = powerup.powerupIcon;
        //Set the ability to give
        newDrop.GetComponent<GivePowerupOnTouch>().SetAbilityToGive(powerup);

        healthManager.RemoveObserver(this);
    }
}
