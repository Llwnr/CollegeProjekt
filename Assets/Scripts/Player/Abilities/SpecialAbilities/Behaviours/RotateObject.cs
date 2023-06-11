using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed;
    public Vector3 rotateDir = new Vector3(0,0,1);

    public void SetRotateSpeed(float amt){
        rotateSpeed = amt;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateDir*rotateSpeed, Space.Self);
    }
}
