using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]private Vector3 offset;
    [SerializeField]private Transform target;
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position+offset;
    }
}
