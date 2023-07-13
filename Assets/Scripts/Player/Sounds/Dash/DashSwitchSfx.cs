using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class DashSwitchSfx : MonoBehaviour
{
    [SerializeField]private EventReference sfx;
    private EventInstance dashSwitchSfx;
    // Start is called before the first frame update
    void Start()
    {
        dashSwitchSfx = RuntimeManager.CreateInstance(sfx);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            dashSwitchSfx.start();
        }
    }
}
