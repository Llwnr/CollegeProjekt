using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ShootCircular : ActionNode
{
    public GameObject bullet;
    public int numOfBullets;
    public float shootForce;
    public float shootInterval;
    private float shootIntervalCount;
    public float shootAngle;

    public float duration;
    private float durationCounter;

    public float offsetIncrement;
    public float offset = 0;

    private GameObject player;
    private float playerAngle = 0;

    protected override void OnStart()
    {
        player = GameObject.FindWithTag("Player");
        ResetDuration();
        ShootBullets();
        ResetShootInterval();
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        
        shootIntervalCount -= Time.deltaTime;
        if(shootIntervalCount < 0){
            ResetShootInterval();
            ShootBullets();
        }
        durationCounter -= Time.deltaTime;
        if(durationCounter > 0) return State.Running;
        
        return State.Success;
    }

    void ShootBullets(){
        Vector2 playerDir = player.transform.position - context.transform.position;
        playerAngle = Mathf.Atan2(playerDir.y, playerDir.x);


    
        //Create and shoot bullets in a circular area
        for(int i=0; i<numOfBullets; i++){
            Rigidbody2D newBullet = GameObject.Instantiate(bullet, context.transform.position + new Vector3(0,0,-1), Quaternion.identity).GetComponent<Rigidbody2D>();
            Vector2 dirToShoot;
            float baseAngle = Mathf.PI * 2 * ((i-(int)numOfBullets/2)*360 + offset);
            //To spread each bullet perfectly where distance between all bullets are the same rate
            float angleDivisor = numOfBullets*360;
            float angleLimiter = 360/shootAngle;
            float angle = baseAngle/(angleDivisor*angleLimiter) + playerAngle;
            
            // dirToShoot.x = Mathf.Sin(angle/(360/shootAngle));
            // dirToShoot.y = Mathf.Cos(angle/(360/shootAngle));
            dirToShoot.x = Mathf.Cos(angle);
            dirToShoot.y = Mathf.Sin(angle);
            newBullet.AddForce(dirToShoot*shootForce, ForceMode2D.Impulse);
        }

        //To rotate the bullet's direction after every shooting
        offset += offsetIncrement;
    }

    void ResetDuration(){
        durationCounter = duration;
    }
    void ResetShootInterval(){
        shootIntervalCount = shootInterval;
    }
}

