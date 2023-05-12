using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesPanel : MonoBehaviour
{
    [SerializeField]private List<Upgrade> upgrades;
    [SerializeField]private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Upgrade upgrade in upgrades){
            GameObject newPanel = Instantiate(panel, Vector3.zero, Quaternion.identity);
            newPanel.transform.SetParent(transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
