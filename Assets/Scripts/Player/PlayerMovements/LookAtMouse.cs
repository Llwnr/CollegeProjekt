using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private BallDash ballDash;
    private void Start() {
        ballDash = GetComponent<BallDash>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        LookAtMousePos();
    }

    void LookAtMousePos(){
        //Don't change rotation when ball is dashing
        if(ballDash && ballDash.IsBallDashing()) return;
        Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0, angle-90);
    }
}
