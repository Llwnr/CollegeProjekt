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
    private Vector2 dirToDash = Vector2.zero;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dash at direction pointed by mouse
        if(Input.GetMouseButtonDown(0)){
            rb.velocity = Vector2.zero;
            dirToDash = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)*10f;
            dirToDash = dirToDash.normalized;
            Debug.Log(dirToDash);
            rb.AddForce(dirToDash*dashForce, ForceMode2D.Impulse);
            AddSpeedLimit();
        }
    }

    void AddSpeedLimit(){
        GetComponent<LimitBallSpeed>().AddSpeedLimiter(maxDashSpeed, duration);
    }
}
