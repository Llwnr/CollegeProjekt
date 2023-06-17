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
    public bool aimPlayer = false;
    private float playerAngle = 0;

    public GameObject cannon;
    private List<GameObject> cannons = new List<GameObject>();

    protected override void OnStart()
    {
        player = GameObject.FindWithTag("Player");
        ResetDuration();
        ShootBullets();
        ResetShootInterval();
    }

    protected override void OnStop()
    {
        foreach(GameObject myCannon in cannons){
            GameObject.Destroy(myCannon);
        }
        cannons.Clear();
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
        if(aimPlayer)
            playerAngle = Mathf.Atan2(playerDir.y, playerDir.x);
        else playerAngle = 0;


    
        //Create and shoot bullets in a circular area
        for(int i=0; i<numOfBullets; i++){
            Vector2 dirToShoot;
            float baseAngle = Mathf.PI * 2 * ((i-(int)numOfBullets/2)*360 + offset);
            //To spread each bullet perfectly where distance between all bullets are the same rate
            float angleDivisor = numOfBullets*360;
            float angleLimiter = 360/shootAngle;
            float angle = baseAngle/(angleDivisor*angleLimiter) + playerAngle + context.transform.localEulerAngles.z*Mathf.Deg2Rad;
            
            // dirToShoot.x = Mathf.Sin(angle/(360/shootAngle));
            // dirToShoot.y = Mathf.Cos(angle/(360/shootAngle));
            dirToShoot.x = Mathf.Cos(angle);
            dirToShoot.y = Mathf.Sin(angle);
            
            //Make cannons that will shoot
            if(cannons.Count < numOfBullets){
                GameObject newCannon = GameObject.Instantiate(cannon, new Vector3(dirToShoot.x, dirToShoot.y, -1)/2f, Quaternion.identity);
                cannons.Add(newCannon);
                newCannon.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(dirToShoot.y, dirToShoot.x)*Mathf.Rad2Deg - 90);
                newCannon.transform.SetParent(context.transform, false);
            }


            Rigidbody2D newBullet = GameObject.Instantiate(bullet, context.transform.position + new Vector3(dirToShoot.x, dirToShoot.y,-1)/2.5f, Quaternion.identity).GetComponent<Rigidbody2D>();
            // newBullet.transform.SetParent(context.transform, false);
            // newBullet.transform.localScale /= context.transform.localScale.x;
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

