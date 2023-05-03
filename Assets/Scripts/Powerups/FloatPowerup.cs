using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPowerup : MonoBehaviour
{
    private Vector3 origPos;
    [SerializeField]private Vector3 targetPos;
    [SerializeField]private AnimationCurve curve;

    private bool reverse = false;
    [SerializeField]private float timer = 0;
    [SerializeField]private float speed;

    private void Awake() {
        origPos = transform.position;
        targetPos += origPos;
    }

    private void Update() {
        //Make powerup float up and down
        if(!reverse){
            timer += Time.deltaTime*speed;
            if(timer >= 1) reverse = true;
        }else{
            timer -= Time.deltaTime*speed;
            if(timer <= 0) reverse = false;
        }
        transform.position = new Vector3(origPos.x, Mathf.Lerp(origPos.y, targetPos.y, curve.Evaluate(timer)), origPos.z);
    }

}
