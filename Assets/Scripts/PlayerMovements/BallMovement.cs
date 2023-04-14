using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header ("Move Speed")]
    [SerializeField]private float moveSpeed;
    [SerializeField]private float maxMoveSpeed;

    private Rigidbody2D rb;

    private float hDir, vDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the direction to move to
        GetDirection();
        MoveBall();
    }

    void GetDirection(){
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
    }

    void MoveBall(){
        rb.AddForce(new Vector2(hDir, vDir)*moveSpeed);
    }

    public float GetNormalMoveSpeed(){
        return maxMoveSpeed;
    }
}
