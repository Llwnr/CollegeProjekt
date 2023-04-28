using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronSelectionRotation : MonoBehaviour
{
    [SerializeField]int mouseScrollAmt = 0;
    float timer = 0;
    private bool rotationEnded = false;
    [SerializeField]float speed;
    float zAngleBeforeRot;
    // Start is called before the first frame update
    void Start()
    {
        zAngleBeforeRot = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y != 0 && Mathf.Abs(Input.mouseScrollDelta.y) > Mathf.Abs(mouseScrollAmt)){
            mouseScrollAmt = (int)Input.mouseScrollDelta.y;
            timer -= timer*0.4f;
            if(timer < 0) timer = 0;
            rotationEnded = false;
        }
        if(rotationEnded) return;
        timer += Time.deltaTime*speed;
        if(timer > 1){
            timer = 1;
            transform.localEulerAngles = new Vector3(0,0, Mathf.Lerp(zAngleBeforeRot, zAngleBeforeRot+mouseScrollAmt*90f, timer));
            rotationEnded = true;
            timer = 0;
            mouseScrollAmt = 0;
            zAngleBeforeRot = transform.localEulerAngles.z;
            return;
        }
        transform.localEulerAngles = new Vector3(0,0, Mathf.Lerp(zAngleBeforeRot, zAngleBeforeRot+mouseScrollAmt*90f, timer));
        
    }
}
