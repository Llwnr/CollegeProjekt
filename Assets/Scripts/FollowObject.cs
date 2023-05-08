using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Vector3 offset;
    [SerializeField]private Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position+offset;
    }

    public void SetTarget(Transform target){
        this.target = target;
    }
}
