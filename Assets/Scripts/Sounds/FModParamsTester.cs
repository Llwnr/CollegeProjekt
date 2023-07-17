using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FModParamsTester : MonoBehaviour
{
    [SerializeField]private EventReference sfx;
    private EventInstance testParams;
    // Start is called before the first frame update
    void Start()
    {
        testParams = RuntimeManager.CreateInstance(sfx);
        testParams.start();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            float pitchVal;
            testParams.getParameterByName("Pitch", out pitchVal);
            testParams.setParameterByName("Pitch", pitchVal+1);
            
        }
        if(Input.GetKeyDown(KeyCode.H)){
            float pitchVal;
            testParams.getParameterByName("Pitch", out pitchVal);
            testParams.setParameterByName("Pitch", pitchVal-1);
        }
    }
}
