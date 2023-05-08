using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        LookAtMousePos();
    }

    void LookAtMousePos(){
        Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0, angle-90);
    }
}
