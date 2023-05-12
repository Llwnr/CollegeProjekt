using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    private GameObject player;
    private BallDash ballDash;
    private HealthManager playerHealth;

    [SerializeField]private Upgrade someUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        ballDash = player.GetComponent<BallDash>();
        playerHealth = player.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)){
            someUpgrade.Activate();
        }
    }
}
