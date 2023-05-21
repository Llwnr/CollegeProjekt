using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenShopAtEnd : MonoBehaviour
{
    private GameObject[] enemies;
    [SerializeField]private GameObject shop;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
        yield return new WaitForSeconds(3);
        OpenShop();
    }

    public void StartNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OpenShop(){
        shop.SetActive(true);
    }

    void Update()
    {
        ManageFreezeWhileShopping();
    }

    //Don't let player move when shopping
    void ManageFreezeWhileShopping(){
        if(shop.activeSelf){
            Time.timeScale = 0;
            ToggleAllScripts(player, false);
        }else{
            Time.timeScale = 1;
            ToggleAllScripts(player, true);
        }
    }

    private void OnDisable() {
        Time.timeScale = 1;
        ToggleAllScripts(player, true);
    }

    void ToggleAllScripts(GameObject player, bool value){
        if(player != null && player.activeSelf)
        foreach(MonoBehaviour script in player.GetComponents<MonoBehaviour>()){
            script.enabled = value;
        }
    }
}
