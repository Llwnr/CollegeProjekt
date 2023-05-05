using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHealthGrids : MonoBehaviour
{
    private HealthManager playerHealth;
    [SerializeField]private GameObject healthBarToMake;
    private List<GameObject> healthBars = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<HealthManager>();
        CreateHealthBars();
    }

    void CreateHealthBars(){
        for(int i=0; i<playerHealth.GetCurrentHp(); i++){
            GameObject newHealthBar = Instantiate(healthBarToMake, Vector3.zero, Quaternion.identity);
            newHealthBar.transform.SetParent(transform, false);
            healthBars.Add(newHealthBar);
        }
    }
}
