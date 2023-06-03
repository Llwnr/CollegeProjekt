using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPlayer : MonoBehaviour
{
    private GameObject player;
    [SerializeField]private float pullForce;
    [SerializeField]private float radius;
    //For a better gravity like effect
    [SerializeField]private float limitPlayerSlowdownSpeed;
    private float playerOriginalSlowdownSpeed;

    [SerializeField]private float pullPower;
    public float pullTweak;

    RaycastHit2D[] hits;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerOriginalSlowdownSpeed = player.GetComponent<LimitBallSpeed>().GetSlowdownRate();
    }

    void SetPlayerSlowdownRate(float slowdownFactor){
        player.GetComponent<LimitBallSpeed>().SetSlowdownRate(slowdownFactor);
    }

    private void Update() {
        hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.up);
        foreach(RaycastHit2D hit in hits){
            if(hit.transform.CompareTag("Player")){
                PullObject(hit.transform);
                return;
            }
        }
        SetPlayerSlowdownRate(playerOriginalSlowdownSpeed);
    }

    void PullObject(Transform objectToPull){
        Vector2 dir = transform.position - objectToPull.position;
        //Make player friction zero for gravity space like effect
        if(dir.magnitude < radius-0.5f) SetPlayerSlowdownRate(limitPlayerSlowdownSpeed);
        //Pull harder when object is closer
        pullPower = pullTweak/(Vector2.Distance(transform.position, objectToPull.position));
        if(pullPower > 2f) pullPower = 2f;
        dir = dir.normalized;
        
        objectToPull.GetComponent<Rigidbody2D>().AddForce(dir*pullForce*pullPower, ForceMode2D.Force);
    }

    private void OnDisable() {
        SetPlayerSlowdownRate(playerOriginalSlowdownSpeed);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
