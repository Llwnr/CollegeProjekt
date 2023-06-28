using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitVisualExplosion : MonoBehaviour
{
    [SerializeField]private GameObject explosion;
    private GameObject explosionTemp;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy"))
        CreateExplosion(other.contacts[0].point);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy"))
        CreateExplosion(other.ClosestPoint(transform.position));
    }

    private void CreateExplosion(Vector2 hitPoint){
        Debug.Log(hitPoint);
        Instantiate(explosion, hitPoint, Quaternion.identity);
    }
}
