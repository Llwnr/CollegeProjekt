using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class Blast : ActionNode
{
    public GameObject blastExplosion;
    private Transform myTransform, player;

    public float explosionForce;
    private float radius;

    protected override void OnStart() {
        player = GameObject.FindWithTag("Player").transform;
        myTransform = context.transform;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        GameObject.Instantiate(blastExplosion, myTransform.position, Quaternion.identity);
        myTransform.gameObject.SetActive(false);
        radius = blastExplosion.GetComponent<CircleCollider2D>().radius;
        //Knockback force to all colliders in range
        ApplyExplosionForce(radius);
        return State.Success;
    }

    void ApplyExplosionForce(float radius){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(myTransform.position, radius);
        foreach(Collider2D col in colliders){
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            if(rb != null){
                AddExplosionForce(rb, explosionForce, myTransform.position, ForceMode2D.Impulse, radius);
            }
        }
    }

    public static void AddExplosionForce(Rigidbody2D rb, float explosionForce, Vector2 explosionPos, ForceMode2D forceMode, float maxDist){
        Vector2 explosionDir = rb.position - explosionPos;
        if(explosionDir.magnitude == 0){
            explosionDir = new Vector2(0.5f, 0.5f);
        }
        float explosionDist = explosionDir.magnitude/maxDist;

        //Normalize dir
        explosionDir = explosionDir.normalized;

        if(rb.CompareTag("Player")){
            //Manage speed limit
            LimitBallSpeed speedLimitManager = rb.GetComponent<LimitBallSpeed>();
            explosionDist -= 0.35f;
            speedLimitManager.AddSpeedLimiter(explosionForce, 0.2f);
        }

        //Add force
        rb.velocity = Vector2.zero;
        rb.AddForce(explosionDir*Mathf.Lerp(explosionForce, explosionForce*0.2f, explosionDist), forceMode);
        Debug.Log(explosionDist);
    }
}
