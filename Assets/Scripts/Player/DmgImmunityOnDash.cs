using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgImmunityOnDash : MonoBehaviour, IDashObserver
{
    [SerializeField]private float immuneFramesDuration;
    private float immuneFramesCount;
    private HealthManager healthManager;
    private BallDash ballDash;

    private SpriteRenderer spriteRenderer;
    private Color32 origColor;

    private bool immunityActive = false;

    private void Start() {
        healthManager = GameObject.FindWithTag("Player").GetComponent<HealthManager>();
        ballDash = GetComponent<BallDash>();
        ballDash.AddDashObserver(this);

        spriteRenderer = GetComponent<SpriteRenderer>();
        origColor = spriteRenderer.color;
    }

    private void OnDestroy() {
        ballDash.RemoveDashObserver(this);
    }
    
    public void DashStart()
    {
        MakePlayerImmune();
        Color32 transparentColor = origColor;
        transparentColor.a = 50;
        spriteRenderer.color = transparentColor;
    }

    public void DashEnd()
    {
    }

    void MakePlayerImmune(){
        immuneFramesCount = immuneFramesDuration;
        healthManager.SetDmgImmunity(true);
        immunityActive = true;
    }

    private void Update() {
        if(!immunityActive) return;
        immuneFramesCount--;

        if(immuneFramesCount <= 0){
            healthManager.SetDmgImmunity(false);
            immunityActive = false;
            spriteRenderer.color = origColor;           
            //Debug.Log("Dmg Immunity stopped : " + framesForEnd);
        }
    }

    public void IncreaseFrameBy(int amt){
        immuneFramesDuration+=amt;
    }
}
