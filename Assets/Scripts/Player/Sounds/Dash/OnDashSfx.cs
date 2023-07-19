using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class OnDashSfx : MonoBehaviour, IDashObserver
{
    [SerializeField]private EventReference sfx;
    public void DashEnd()
    {
        
    }

    public void DashStart()
    {
        SoundManager.PlaySoundOneShot(sfx);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BallDash>().AddDashObserver(this);
    }
}
