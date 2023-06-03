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
        //Make bullet rotate and face the direction it is moving towards
        Vector2 targetPos = blackboard.direction;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        newBullet.transform.eulerAngles = new Vector3(0,0, angle-90);
        return State.Success;
    }
}
