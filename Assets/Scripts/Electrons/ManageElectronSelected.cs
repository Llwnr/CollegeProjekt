using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ManageElectronSelected : MonoBehaviour
{
    private List<GameObject> electronIcons = new List<GameObject>();
    private List<Color> iconColors = new List<Color>();
    [SerializeField]private GameObject electronIconToMake;
    [SerializeField]private Transform electronBox;
    GameObject prevFrameTopElectron = null;
    GameObject topMostElectron = null;
    [SerializeField]private float speed;
    float timer = 0;
    private ElectronHolder electronHolder;
    // Start is called before the first frame update
    void Start()
    {
        CreateElectronIcons();
        electronHolder = GameObject.FindWithTag("Player").GetComponent<ElectronHolder>();
    }

    void CreateElectronIcons(){
        foreach(ElectronHolder.ElectronType electronType in Enum.GetValues(typeof(ElectronHolder.ElectronType))){
            GameObject newElectron = Instantiate(electronIconToMake, -Vector3.zero, Quaternion.identity);
            electronIcons.Add(newElectron);
            newElectron.GetComponent<MyElectronType>().SetElectronType(electronType);
            newElectron.transform.SetParent(electronBox, false);
            newElectron.GetComponent<Image>().color = GameObject.FindWithTag("Player").GetComponent<ElectronHolder>().GetMyElectronColor(electronType);
            iconColors.Add(newElectron.GetComponent<Image>().color);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Which electron is selected when rotated
        ManageSelection();

        if(Input.GetKeyDown(KeyCode.G)){
            Debug.Log(GetSelectedElectronType());
        }
        //Darken/Grey out electrons that are not available cuz of 0 electron count
        GreyOutUnavailableElectrons();
    }

    void GreyOutUnavailableElectrons(){
        for(int i=0; i<electronIcons.Count; i++){
            GameObject icon = electronIcons[i];
            if(!electronHolder.CanTakeElectron(icon.GetComponent<MyElectronType>().GetElectronType())){
                icon.GetComponent<Image>().color = iconColors[i]*0.5f + new Color32(0,0,0,255);
                //Icon's border color
                icon.transform.GetChild(0).GetComponent<Image>().color = new Color32(90,90,90,255);
            }else{
                icon.GetComponent<Image>().color = iconColors[i];
                icon.transform.GetChild(0).GetComponent<Image>().color = Color.white;
            }
        }
    }

    void ManageSelection(){
        prevFrameTopElectron = topMostElectron;
        //Get the electron at the top most location
        FindTopMostElectron(out topMostElectron);
        
        ManageScale();
    }

    void ManageScale(){
        //If there is no change in switching of electrons, slowly increase scale to max
        if(prevFrameTopElectron == topMostElectron){
            timer += Time.deltaTime*speed;
        }else{//If there is change, reset the scale
            timer = 0;
        }
        //Slowly scale it to show that it is selected
        float lerpScale = Mathf.Lerp(1, 1.6f, timer);
        topMostElectron.transform.localScale = new Vector3(lerpScale,lerpScale,lerpScale);
    }

    void FindTopMostElectron(out GameObject topElectron){
        float electronAtHighestHeight = -10000f;
        topElectron = null;
        foreach(GameObject electron in electronIcons){
            electron.transform.localScale = Vector3.one;
            if(electronAtHighestHeight < electron.transform.position.y){
                electronAtHighestHeight = electron.transform.position.y;
                topElectron = electron;    
            }
        }
    }

    public ElectronHolder.ElectronType GetSelectedElectronType(){
        return topMostElectron.GetComponent<MyElectronType>().GetElectronType();
    }
}
