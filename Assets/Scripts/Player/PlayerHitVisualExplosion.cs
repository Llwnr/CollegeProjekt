using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitVisualExplosion : MonoBehaviour
{
    [SerializeField]private GameObject explosion;
    private GameObject explosionTemp;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy"))
        CreateExplosion(other.contacts[0].point, other.transform);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy"))
        CreateExplosion(other.ClosestPoint(transform.position), other.transform);
    }

    private void CreateExplosion(Vector2 hitPoint, Transform other){
        hitPoint +=  (Vector2)(other.position-transform.position).normalized/(Vector2.Distance(other.position,transform.position)*2.5f);
        Debug.Log(hitPoint);
        Instantiate(explosion, (Vector3)hitPoint+new Vector3(0,0,-10), Quaternion.identity);
    }
}
