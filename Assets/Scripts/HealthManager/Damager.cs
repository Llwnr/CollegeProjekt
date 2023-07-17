using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private PlayerStats playerStats;
    //To end player dash after all dash calculations such as extra speed, buffs are calculated
    private bool endPlayerDash = false;
    private void Awake() {
        playerStats = GetComponent<PlayerStats>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy")){
            other.transform.GetComponent<IDamagable>().DealDamage(playerStats.GetMyMaxDamage(), other.transform);
            endPlayerDash = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            other.transform.GetComponent<IDamagable>().DealDamage(playerStats.GetMyMaxDamage(), other.transform);
        }
    }

    void LateUpdate(){
        if(!endPlayerDash) return;

        GetComponent<BallDash>().DashEnd();
        Debug.Log("Dash ended at last update after collision");
        endPlayerDash = false;
    }
}
