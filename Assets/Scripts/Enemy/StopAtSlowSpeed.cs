using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAtSlowSpeed : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity *= 0.99f;
        if(Mathf.Abs(rb.velocity.magnitude) < 0.2f) rb.velocity = Vector2.zero;
    }
}
