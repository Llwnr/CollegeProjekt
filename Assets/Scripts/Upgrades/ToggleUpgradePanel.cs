using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUpgradePanel : MonoBehaviour
{
    [SerializeField]private GameObject upgradePanel;
    private GameObject player;

    private void Start() {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            upgradePanel.SetActive(!upgradePanel.activeSelf);
            if(upgradePanel.activeSelf){
                Time.timeScale = 0;
                ToggleAllScripts(player, false);
            }else{
                Time.timeScale = 1;
                ToggleAllScripts(player, true);
            }
        }
    }

    void ToggleAllScripts(GameObject player, bool value){
        foreach(MonoBehaviour script in player.GetComponents<MonoBehaviour>()){
            script.enabled = value;
        }
    }
}
