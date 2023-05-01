using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayElectronCount : MonoBehaviour
{
    [SerializeField]private ElectronHolder electronHolder;
    [SerializeField]private List<ElectronHolder.ElectronType> electronTypes = new List<ElectronHolder.ElectronType>();
    //The info box to create/update to show electron count
    [SerializeField]private GameObject electronInfoBox;
    private List<GameObject> infoBoxes = new List<GameObject>();
    [SerializeField]private Sprite electronIconSprite;

    private void Start() {
        CreateInfoBoxesForEachElectron();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateElectronCount();
    }

    void CreateInfoBoxesForEachElectron(){
        foreach(ElectronHolder.ElectronType electronType in Enum.GetValues(typeof(ElectronHolder.ElectronType))){
            if(electronType == ElectronHolder.ElectronType.grey) continue;
            electronTypes.Add(electronType);
            GameObject infoBox = Instantiate(electronInfoBox, Vector3.zero, Quaternion.identity);
            infoBox.transform.SetParent(transform, false);
            infoBoxes.Add(infoBox);
        }
    }

    void UpdateElectronCount(){
        for(int i=0; i<infoBoxes.Count; i++){
            TextMeshProUGUI textBox = infoBoxes[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            Image electronIcon = infoBoxes[i].transform.GetChild(0).GetComponent<Image>();
            ElectronHolder.ElectronType electronType = electronTypes[i];
            textBox.text = electronHolder.GetMyElectronCount(electronType).ToString();
            electronIcon.sprite = electronIconSprite;
            electronIcon.color = electronHolder.GetMyElectronColor(electronType);
        }
    }
}
