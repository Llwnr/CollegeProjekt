using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamager : MonoBehaviour
{
    [SerializeField]private float dmgAmt;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy")){
            other.transform.GetComponent<IDamagable>().DealDamage(dmgAmt, transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            other.transform.GetComponent<IDamagable>().DealDamage(dmgAmt, transform);
        }
    }
}
