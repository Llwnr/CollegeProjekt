using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    private GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //If there was no enemy at the start of the scene, it may be a tutorial or menu level. Don't go to next level in that case
        if(enemies.Length <= 0) return;
        StartCoroutine(CheckIfEnemiesDead());
    }

    IEnumerator CheckIfEnemiesDead(){
        //Every second check if enemies are dead. If all are dead then go to next scene
        yield return new WaitForSeconds(1);
        for(int i=0; i<enemies.Length; i++){
            if(enemies[i].activeSelf){
                StartCoroutine(CheckIfEnemiesDead());
                yield break;
            }
        }
        StartNextLevel();
    }

    void StartNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
