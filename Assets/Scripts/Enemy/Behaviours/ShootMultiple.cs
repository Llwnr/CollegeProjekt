using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ShootMultiple : ActionNode
{
    public GameObject bullet;
    public float shootForce;
    public float spreadAngle;
    public int numOfBullets;

    public float throwDuration;
    private float durationCount;

    private int i;

    private Vector2 targetDir;
    protected override void OnStart() {
        ResetThrowDuration();
        i = 0;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        targetDir = GameObject.FindWithTag("Player").transform.position - context.transform.position;
        Vector2 spreadDir = Vector2.zero;
        float newSpreadAngle;
        //Only throw one bullet at a time even with spread
        durationCount -= Time.deltaTime;
        //Find angle to player
        float playerTargetAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        if(durationCount < 0){
            ResetThrowDuration();
            //Spread it weirdly
            float randomSpread = Random.Range(-spreadAngle, spreadAngle);
            newSpreadAngle = playerTargetAngle + randomSpread;
            spreadDir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * newSpreadAngle), Mathf.Sin(Mathf.Deg2Rad * newSpreadAngle));
            ThrowBullet(spreadDir);
            i++;
        }

        if(i >= numOfBullets) return State.Success;
        else return State.Running;
    }

    void ResetThrowDuration(){
        durationCount = throwDuration;
    }

    void ThrowBullet(Vector2 dir){
        GameObject newBullet = GameObject.Instantiate(bullet, context.transform.position, Quaternion.identity);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(dir*shootForce, ForceMode2D.Impulse);
    }
}
