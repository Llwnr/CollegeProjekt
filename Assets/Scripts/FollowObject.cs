using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Vector3 offset;
    [SerializeField]private Transform target;
    [SerializeField]private bool lerp = false;
    [SerializeField]private float lerpSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        if(!target) return;
        if(lerp)
            transform.position = Vector3.Lerp(transform.position, target.position+offset, lerpSpeed * Time.deltaTime);
        else{
            transform.position = target.position+offset;
        }
    }

    public void SetTarget(Transform target){
        this.target = target;
    }
    public void SetLerpSpeed(float value){
        lerp = true;
        lerpSpeed = value;
    }
}
