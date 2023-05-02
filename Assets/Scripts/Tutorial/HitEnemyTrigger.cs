using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemyTrigger : MonoBehaviour
{
    [SerializeField]private GameObject electronSelectionBox;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy") && TutorialManager.instance.GetIndex() > 3){
            StartCoroutine(NextTutorial());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy") && TutorialManager.instance.GetIndex() > 3){
            StartCoroutine(NextTutorial());
        }
    }

    IEnumerator NextTutorial(){
        yield return new WaitForSeconds(10);
        TutorialManager.instance.UpdateText();
        electronSelectionBox.SetActive(true);
        Destroy(this);
    }
}
