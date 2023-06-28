using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField]private bool isPlayer = false;
    [SerializeField]private float offset = 0;
    [SerializeField]private float rotSpeed = 1; 
    private float angle;
    private float lerpDist;
    // Start is called before the first frame update
    void Start()
    {
        if(isPlayer){
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position - transform.position;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        //Prevent full round spin
        lerpDist = transform.eulerAngles.z - (angle-90+offset);
        if(lerpDist > 180){
            angle += 360;
        }
        transform.eulerAngles = new Vector3(0,0, Mathf.Lerp(transform.eulerAngles.z, angle-90+offset, rotSpeed*Time.deltaTime));
        

        // Vector3 dir = target.position - transform.position;
        // Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed*Time.deltaTime);
        // rot.x = rot.y = 0;
        // transform.rotation = rot;
    }
}
