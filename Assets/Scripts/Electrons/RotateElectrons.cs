using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;


public class RotateElectrons : MonoBehaviour
{
    public static RotateElectrons instance {get; private set;}

    
    [SerializeField]private Vector2 rotateOffset;
    [SerializeField]private float rotateSpeed;
    private Vector2 rotateAmt;

    private List<Transform> electrons = new List<Transform>();
    private void Awake() {
        if(instance != null){
            Debug.LogError("More than one rotate electrons");
            return;
        }
        instance = this;

        rotateAmt = rotateOffset*rotateSpeed;
    }

    public void AddElectronToRotate(Transform electron){
        electrons.Add(electron);
    }

    public void RemoveElectron(Transform electron){
        electrons.Remove(electron);
        Destroy(electron.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        RotateMyElectrons();
        RemoveDisabledElectrons();
    }

    void RotateMyElectrons(){
        for(int i=0; i<electrons.Count; i++){
            electrons[i].Rotate(rotateAmt);
        }
    }

    void RemoveDisabledElectrons(){
        for(int i=0; i<electrons.Count; i++){
            if(!electrons[i].gameObject.activeSelf){
                RemoveElectron(electrons[i]);
                i--;
            }
        }
    }
}



