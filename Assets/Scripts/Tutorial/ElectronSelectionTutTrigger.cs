using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronSelectionTutTrigger : MonoBehaviour
{
    int noOfTimesDone = 0;
    [SerializeField]private GameObject electronSelectionBox;
    private void Update() {
        if(Input.mouseScrollDelta.y != 0 && electronSelectionBox.activeSelf){
            noOfTimesDone++;
        }
        if(noOfTimesDone > 3){
            StartCoroutine(GoToNextTut());
            noOfTimesDone = -1000;
        }
    }

    IEnumerator GoToNextTut(){
        yield return new WaitForSeconds(4);
        TutorialManager.instance.UpdateText();
        Destroy(this);
    }
}
