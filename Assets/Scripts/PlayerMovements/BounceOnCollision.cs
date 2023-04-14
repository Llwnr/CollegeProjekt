using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 velocityOnHit;
    [SerializeField]private float bounceDuration;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        velocityOnHit = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy")){
            float speed = velocityOnHit.magnitude;
            Debug.Log(speed);
            Vector2 dir = Vector2.Reflect(velocityOnHit.normalized, other.contacts[0].normal);

            rb.velocity = dir * speed;

            AddLimiter();
            StartCoroutine(SlowDownBounce());
        }
    }

    void AddLimiter(){
        GetComponent<LimitBallSpeed>().AddSpeedLimiter(20, bounceDuration);
    }

    IEnumerator SlowDownBounce(){
        rb.velocity *= 0.85f;
        yield return null;
        StartCoroutine(SlowDownBounce());
    }
}
