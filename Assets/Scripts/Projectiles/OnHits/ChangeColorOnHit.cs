using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnHit : MonoBehaviour, IOnDamage
{
    private Color32 origColor;
    [SerializeField]private Color32 colorWhenHit;

    [SerializeField]private float duration;
    private float durationCount;
    
    private void OnEnable() {
        GetComponent<BaseHealthManager>().AddObserver(this);
        origColor = GetComponent<SpriteRenderer>().color;
    }

    public void ActivateWhenDamaged(float dmgAmt, Transform myTransform)
    {
        durationCount = duration;
    }

    private void Update() {
        durationCount -= Time.deltaTime;
        if(durationCount > duration/1.4f){
            //Slowly go from orig color to hit color to orig color
            SwitchToHitColor();
        }else{
            SwitchToOrigColor();
        }
    }

    void SwitchToHitColor(){
        float lerpValue = 1 - durationCount/duration;
        GetComponent<SpriteRenderer>().color = Color32.Lerp(origColor, colorWhenHit, lerpValue+0.8f);
    }

    void SwitchToOrigColor(){
        float lerpValue = 1 - durationCount/duration;
        GetComponent<SpriteRenderer>().color = Color32.Lerp(colorWhenHit, origColor, lerpValue);
    }
}
