using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class DashHitSfx : MonoBehaviour
{
    [SerializeField]private EventReference hitSfx;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy")){
            SoundManager.PlaySoundOneShot(hitSfx);
        }
    }
}
