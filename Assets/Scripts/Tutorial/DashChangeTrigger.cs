using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashChangeTrigger : MonoBehaviour
{
    private int dashChangedCount = 0;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            dashChangedCount++;
        }

        if(dashChangedCount > 3){
            TutorialManager.instance.UpdateText();
            gameObject.SetActive(false);
        }
    }
}
