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

    public void RaycastTriggered(GameObject fromObject){
        DamageTarget(fromObject);
    }

    void DamageTarget(GameObject other){
        if(neutralized) return;
        if(other.CompareTag("Player")){
            //Notify that player has been collided either by unity's system or by raycast
            other.GetComponent<DmgImmunityOnDash>().PlayerCollidedWithBullet(GetComponent<Collider2D>());
            other.GetComponent<IDamagable>().DealDamage(dmgAmt, transform);    
            if(transform.CompareTag("Projectile")) {
                Destroy(gameObject);
                //Failsafe mechanic incase the projectile hits player twice, only activate it once
                neutralized = true;
            }
        }
    }

    public void SetNeutralization(bool value){
        neutralized = value;
    }
}
