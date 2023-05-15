using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private bool neutralized = false;
    [SerializeField]private float dmgAmt;
    private void OnCollisionEnter2D(Collision2D other) {
        DamageTarget(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageTarget(other.gameObject);
    }

    void DamageTarget(GameObject other){
        if(neutralized) return;
        if(other.CompareTag("Player")){
            other.GetComponent<IDamagable>().DealDamage(dmgAmt);    
            Destroy(gameObject);
        }
    }

    public void SetNeutralization(bool value){
        neutralized = value;
    }
}
