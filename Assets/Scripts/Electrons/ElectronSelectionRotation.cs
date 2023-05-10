using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronSelectionRotation : MonoBehaviour
{
    int mouseScrollAmt = 0;
    [SerializeField]private Transform electronBox;
    float timer = 0;
    private bool rotationEnded = false;
    [SerializeField]float speed;
    float zAngleBeforeRot;
    private ManageElectronSelected electronSelector;

    private BallDash ballDash;

    private int lastInput = 1;
    // Start is called before the first frame update
    void Start()
    {
        ballDash = GameObject.FindWithTag("Player").GetComponent<BallDash>();
        zAngleBeforeRot = electronBox.localEulerAngles.z;
        electronSelector = GetComponent<ManageElectronSelected>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.mouseScrollDelta.y != 0){
        //     lastInput = (int)Input.mouseScrollDelta.y;
        // }
        // if(Input.mouseScrollDelta.y != 0 && Mathf.Abs(Input.mouseScrollDelta.y) > Mathf.Abs(mouseScrollAmt)){
        //     mouseScrollAmt = (int)Input.mouseScrollDelta.y;
        //     timer -= timer*0.4f;
        //     if(timer < 0) timer = 0;
        //     rotationEnded = false;
        // }
        if(Input.GetKeyDown(KeyCode.Q)){
            mouseScrollAmt = 0;
            timer -= timer*0.4f;
            if(timer < 0) timer = 0;
            rotationEnded = false;
        }
        if(Input.GetKeyDown(KeyCode.W)){
            mouseScrollAmt = 1;
            timer -= timer*0.4f;
            if(timer < 0) timer = 0;
            rotationEnded = false;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            mouseScrollAmt = 2;
            timer -= timer*0.4f;
            if(timer < 0) timer = 0;
            rotationEnded = false;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            mouseScrollAmt = 3;
            timer -= timer*0.4f;
            if(timer < 0) timer = 0;
            rotationEnded = false;
        }
        if(rotationEnded) return;
        timer += Time.deltaTime*speed;
        if(timer > 1){
            timer = 1;
            electronBox.localEulerAngles = new Vector3(0,0, Mathf.Lerp(zAngleBeforeRot, 45+mouseScrollAmt*90f, timer));
            rotationEnded = true;
            timer = 0;
            mouseScrollAmt = 0;
            zAngleBeforeRot = electronBox.localEulerAngles.z;
            return;
        }
        electronBox.localEulerAngles = new Vector3(0,0, Mathf.Lerp(zAngleBeforeRot, 45+mouseScrollAmt*90f, timer));
    }
    private void LateUpdate() {
        //If the top most electron is not available then rotate again
        if((timer > 0.85f || timer == 0) && !electronSelector.IsSelectedElectronAvailable() && !ballDash.IsBallDashing()){
            mouseScrollAmt += (int)Mathf.Sign(lastInput);
            timer -= timer*0.4f;
            rotationEnded = false;
        }
    }
}


