using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextTutorial : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        //When touching a point, go to next tutorial text
        if(other.transform.CompareTag("Player")){
            TutorialManager.instance.UpdateText();
            gameObject.SetActive(false);
        }
    }
}
