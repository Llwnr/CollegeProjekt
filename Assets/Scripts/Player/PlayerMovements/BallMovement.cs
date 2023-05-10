using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header ("Move Speed")]
    [SerializeField]private float moveSpeed;
    [SerializeField]private float maxMoveSpeed;
    private BallDash ballDash;
    private float extraMoveSpeed = 0;

    private Rigidbody2D rb;

    private float hDir = 0, vDir = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballDash = GetComponent<BallDash>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the direction to move to
        GetDirection();
    }

    private void FixedUpdate() {
        //MoveBall();
    }

    void GetDirection(){
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
    }

    void MoveBall(){
        if(ballDash.IsBallDashing())return;
        rb.AddForce(new Vector2(hDir, vDir)*moveSpeed, ForceMode2D.Force);
    }

    public float GetNormalMoveSpeed(){
        //Return normal or basic movement speed of player when its not dashing or being knocked back
        return maxMoveSpeed+extraMoveSpeed;
    }

    public void SetExtraMoveSpeed(float amt){
        //For some buffs. Basically increase movespeed
        extraMoveSpeed = amt;
    }
}
