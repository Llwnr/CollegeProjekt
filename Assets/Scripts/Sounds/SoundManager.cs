using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SoundManager : MonoBehaviour
{
    //Only for playing sounds that can't be stopped
    public static EventInstance PlaySoundOneShot(EventReference sfx){
        EventInstance sfxInstance = RuntimeManager.CreateInstance(sfx);
        //return sfxInstance;
        sfxInstance.start();
        return sfxInstance;
    }

}
