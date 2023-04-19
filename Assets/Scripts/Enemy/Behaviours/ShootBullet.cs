using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ShootBullet : ActionNode
{
    public GameObject bullet;
    public float shootForce;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        GameObject newBullet = GameObject.Instantiate(bullet, context.transform.position, Quaternion.identity);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(blackboard.direction*shootForce, ForceMode2D.Impulse);
        return State.Success;
    }
}
