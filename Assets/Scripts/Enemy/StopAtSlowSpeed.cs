using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAtSlowSpeed : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private float slowdownRate = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity *= 1-slowdownRate;
        if(Mathf.Abs(rb.velocity.magnitude) < 0.2f) rb.velocity = Vector2.zero;
    }
}
