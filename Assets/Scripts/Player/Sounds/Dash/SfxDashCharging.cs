using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SfxDashCharging : MonoBehaviour
{
    [SerializeField]private EventReference sfx;
    [SerializeField]private EventReference maxChargeReachedSfx;
    private EventInstance currentSfx;
    private EventInstance maxChargeSfx;
    private BallDash ballDash;
    //To stop looping sfx and also to stop playing once it hits an enemy
    private bool stoppedPlaying = true;
    private bool reachedMaxCharge = false;

    void Start()
    {
        currentSfx = RuntimeManager.CreateInstance(sfx);
        maxChargeSfx = RuntimeManager.CreateInstance(maxChargeReachedSfx);
        ballDash = GetComponent<BallDash>();
    }

    private void LateUpdate() {
        //Play sound when ball is charing
        if(ballDash.IsBallCharging() && !ballDash.IsAtMaxCharge()){
            PLAYBACK_STATE playbackState;
            currentSfx.getPlaybackState(out playbackState);
            //Play sound once and wait for it to finish 
            if(playbackState.Equals(PLAYBACK_STATE.STOPPED)  && stoppedPlaying){
                StartPlayingCharingSfx();
            }
        }else{
            StopPlayingChargingSfx();
        }

        //Play once only when reaching max charge
        if(ballDash.IsAtMaxCharge() && !reachedMaxCharge){
            reachedMaxCharge = true;
            StartPlayingMaxChargeSfx();
        }
        if(!ballDash.IsAtMaxCharge()){
            reachedMaxCharge = false;
            maxChargeSfx.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Enemy")) StopPlayingChargingSfx();
    }

    void StartPlayingMaxChargeSfx(){
        maxChargeSfx.start();
    }

    void StartPlayingCharingSfx(){
        currentSfx.start();
        stoppedPlaying = false;
    }

    void StopPlayingChargingSfx(){
        currentSfx.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        stoppedPlaying = true;
    }


}
