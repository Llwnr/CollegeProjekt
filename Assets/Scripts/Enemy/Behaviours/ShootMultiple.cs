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
    public float offset;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        int indexDivisor = numOfBullets/2;
        Vector3 spreadDir = Vector3.zero;
        float newSpreadAngle;
        for(int i=0; i<numOfBullets; i++){
            float playerTargetAngle = Mathf.Atan2(blackboard.direction.y, blackboard.direction.x) * Mathf.Rad2Deg;
            newSpreadAngle = playerTargetAngle + spreadAngle * (i-indexDivisor) + offset;
            spreadDir = new Vector2(Mathf.Sin(Mathf.Deg2Rad * newSpreadAngle), Mathf.Cos(Mathf.Deg2Rad * newSpreadAngle));
            GameObject newBullet = GameObject.Instantiate(bullet, context.transform.position, Quaternion.identity);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce((spreadDir)*shootForce, ForceMode2D.Impulse);
            Debug.Log("P Target angle: " + playerTargetAngle);
            Debug.Log("Angle: " + newSpreadAngle);
            Vector3 targetDir = new Vector2(Mathf.Sin(playerTargetAngle), Mathf.Cos(playerTargetAngle));
            Debug.DrawLine(context.transform.position, context.transform.position+targetDir, Color.red, 10);
        }
        return State.Success;
    }
}
