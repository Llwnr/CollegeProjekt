using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedInfo : MonoBehaviour
{
    private Rigidbody2D rb;
    private float prevFrameSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate() {
        prevFrameSpeed = rb.velocity.magnitude;
    }

    public float GetSpeed(){
        return prevFrameSpeed;
    }
}
