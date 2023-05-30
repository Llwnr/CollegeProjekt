using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatePlayerHit : MonoBehaviour, IOnDamage
{
    [SerializeField]private Color32 damagedColor;
    private Color32 origColor;

    [SerializeField]private float duration;
    private float durationCount;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        origColor = spriteRenderer.color;
        GetComponent<BaseHealthManager>().AddObserver(this);
    }

    public void ActivateWhenDamaged(float dmgAmt, Transform myTransform)
    {
        durationCount = duration;   
    }

    private void Update() {
        if(durationCount > 0){
            durationCount -= Time.deltaTime;
            spriteRenderer.color = Color32.Lerp(origColor, damagedColor, durationCount/duration);
        }
    }

}
