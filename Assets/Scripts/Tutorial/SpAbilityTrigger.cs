using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpAbilityTrigger : MonoBehaviour
{
    private bool onlyOnce = true;
    // Update is called once per frame
    void Update()
    {
        if(TutorialManager.instance.GetIndex() > 4 && Input.GetMouseButtonDown(1)){
            if(onlyOnce){
                onlyOnce = false;
                TutorialManager.instance.UpdateText();
                StartCoroutine(GoToFirstLevel());
            }
        }
    }

    IEnumerator GoToFirstLevel(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Lvl1");
    }
}
