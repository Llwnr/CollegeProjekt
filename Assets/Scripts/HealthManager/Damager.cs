using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private PlayerStats playerStats;
    private void Awake() {
        playerStats = GetComponent<PlayerStats>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy")){
            Debug.Log("col");
            other.transform.GetComponent<IDamagable>().DealDamage(playerStats.GetMyMaxDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            other.transform.GetComponent<IDamagable>().DealDamage(playerStats.GetMyMaxDamage());
        }
    }
}
