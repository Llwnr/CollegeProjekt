using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScrollTest : MonoBehaviour
{
    private int maxAmt = 4;
    private List<GameObject> electronIcons = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform transform in transform.GetComponentsInChildren<Transform>()){
            if(transform.name != name){
                electronIcons.Add(transform.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 0, Input.mouseScrollDelta.y*90);
        if(Input.mouseScrollDelta.y != 0){
            ManageScale();
        }
    }

    void ManageScale(){
        float electronAtHighestHeight = -10000f;
        GameObject topMostElectron = null;
        foreach(GameObject electron in electronIcons){
            electron.transform.localScale = Vector3.one;
            if(electronAtHighestHeight < electron.transform.position.y){
                electronAtHighestHeight = electron.transform.position.y;
                topMostElectron = electron;
            }
        }
        topMostElectron.transform.localScale = new Vector3(1.6f,1.6f,1.6f);
    }
}
