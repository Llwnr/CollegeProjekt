using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]private Vector3 offset;
    [SerializeField]private Transform target;
    [SerializeField]private bool convertToCanvas = false;
    [SerializeField]private bool rotateWithTarget = false;
    // Update is called once per frame
    void Update()
    {   
        if(convertToCanvas){
            transform.position = Camera.main.WorldToScreenPoint(target.position+offset);
        }else{
            transform.position = target.position+offset;
        }

        if(rotateWithTarget){
            transform.localEulerAngles = target.localEulerAngles;
        }
    }
}
