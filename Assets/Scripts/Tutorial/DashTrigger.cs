using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrigger : MonoBehaviour
{
    private int dashCount = 0;

    private void Update() {
        if(Input.GetMouseButtonUp(0)){
            dashCount++;
        }

        if(dashCount > 2){
            TutorialManager.instance.UpdateText();
            gameObject.SetActive(false);
        }
    }


}
