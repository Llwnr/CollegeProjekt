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

    private Vector2 targetDir;
    protected override void OnStart() {
        targetDir = GameObject.FindWithTag("Player").transform.position - context.transform.position;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        int indexDivisor = numOfBullets/2;
        Vector2 spreadDir = Vector2.zero;
        float newSpreadAngle;
        for(int i=0; i<numOfBullets; i++){
            //Find angle to player
            float playerTargetAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            //Spread it
            newSpreadAngle = playerTargetAngle + spreadAngle * (i-indexDivisor);

            spreadDir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * newSpreadAngle), Mathf.Sin(Mathf.Deg2Rad * newSpreadAngle));
            GameObject newBullet = GameObject.Instantiate(bullet, context.transform.position, Quaternion.identity);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce((spreadDir)*shootForce, ForceMode2D.Impulse);
        }
        return State.Success;
    }
}
