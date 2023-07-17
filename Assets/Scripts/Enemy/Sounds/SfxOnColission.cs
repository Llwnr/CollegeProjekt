using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SfxOnColission : MonoBehaviour
{
    [SerializeField]private EventReference sfx;
    private EventInstance sfxInstance;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Player")){
            sfxInstance = SoundManager.PlaySoundOneShot(sfx);
            //Manage sound intensity based on speed of collision
            BallDash ballData = other.transform.GetComponent<BallDash>();
            float intensity = ballData.GetTotalCurrSpeed()/ballData.GetTotalMaxSpeed();
            sfxInstance.setParameterByName("EQ Global", 1-intensity);
        }
    }
}
