using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header ("Move Speed")]
    [SerializeField]private float moveSpeed;
    [SerializeField]private float maxMoveSpeed;

    [Header ("Slowdown Factor")]
    [SerializeField]private float slowdownFactor;

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
        //Slowdown ball when there's no input
        if(hDir == 0 && vDir == 0){
            rb.velocity *= 1-slowdownFactor;
        }
        LookAtMousePos();
    }

    void GetDirection(){
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
    }

    void LookAtMousePos(){
        Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0, angle-90);
    }

    void MoveBall(){
        rb.AddForce(new Vector2(hDir, vDir)*moveSpeed);
    }

    public float GetNormalMoveSpeed(){
        return maxMoveSpeed;
    }
}
