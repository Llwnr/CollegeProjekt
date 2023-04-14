using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDash : MonoBehaviour
{
    [SerializeField]private float dashForce;
    [SerializeField]private float maxDashSpeed;
    [SerializeField]private float duration;
    [SerializeField]private KeyCode dashKey;

    private float hDir, vDir;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
        if(Input.GetKeyDown(dashKey)){
            rb.AddForce(new Vector2(hDir, vDir)*dashForce, ForceMode2D.Impulse);
            AddSpeedLimit();
        }
    }

    void GetDirection(){
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
    }

    void AddSpeedLimit(){
        GetComponent<LimitBallSpeed>().AddSpeedLimiter(maxDashSpeed, duration);
    }
}
