using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ManageElectronSelected : MonoBehaviour
{
    private List<GameObject> electronIcons = new List<GameObject>();
    [SerializeField]private GameObject electronIconToMake;
    GameObject prevFrameTopElectron = null;
    GameObject topMostElectron = null;
    [SerializeField]private float speed;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateElectronIcons();
    }

    void CreateElectronIcons(){
        foreach(ElectronHolder.ElectronType electronType in Enum.GetValues(typeof(ElectronHolder.ElectronType))){
            GameObject newElectron = Instantiate(electronIconToMake, -Vector3.zero, Quaternion.identity);
            electronIcons.Add(newElectron);
            newElectron.GetComponent<MyElectronType>().SetElectronType(electronType);
            newElectron.transform.SetParent(transform, false);
            newElectron.GetComponent<Image>().color = GameObject.FindWithTag("Player").GetComponent<ElectronHolder>().GetMyElectronColor(electronType);
        }
    }
    // Update is called once per frame
    void Update()
    {
        ManageScale();
    }

    void ManageScale(){
        //Get the electron at the top most location
        float electronAtHighestHeight = -10000f;
        prevFrameTopElectron = topMostElectron;
        foreach(GameObject electron in electronIcons){
            electron.transform.localScale = Vector3.one;
            if(electronAtHighestHeight < electron.transform.position.y){
                electronAtHighestHeight = electron.transform.position.y;
                topMostElectron = electron;    
            }
        }
        if(prevFrameTopElectron == topMostElectron){
            timer += Time.deltaTime*speed;
        }else{
            timer = 0;
        }
        //Slowly scale it to show that it is selected
        float lerpScale = Mathf.Lerp(1, 1.6f, timer);
        topMostElectron.transform.localScale = new Vector3(lerpScale,lerpScale,lerpScale);
    }
}
