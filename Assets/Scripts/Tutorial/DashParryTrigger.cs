using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashParryTrigger : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerStats>().GetHasParried()){
            TutorialManager.instance.UpdateText();
            gameObject.SetActive(false);
        }
    }
}
