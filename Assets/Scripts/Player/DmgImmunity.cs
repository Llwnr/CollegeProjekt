using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgImmunity : MonoBehaviour
{
    private BallDash ballDash;
    private HealthManager healthManager;

    [SerializeField]private int extraImmuneFrames;
    private int extraImmuneFramesCount;
    // Start is called before the first frame update
    void Start()
    {
        ballDash = GetComponent<BallDash>();
        healthManager = GetComponent<HealthManager>();

        ResetImmuneFrameCount();
    }

    void ResetImmuneFrameCount(){
        extraImmuneFramesCount = extraImmuneFrames;
    }

    // Update is called once per frame
    void Update(){
        extraImmuneFramesCount--;
        if(extraImmuneFramesCount < 0){
            DeactivateImmunity();
        }
    }

    void ActivateImmunityToDamage(){
        healthManager.SetInvincible(true);
        extraImmuneFramesCount = extraImmuneFrames;
    }

    void DeactivateImmunity(){
        healthManager.SetInvincible(false);
    }
}
