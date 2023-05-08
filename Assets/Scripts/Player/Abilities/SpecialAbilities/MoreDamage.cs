using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

[CreateAssetMenu(fileName = "MoreDamage", menuName = "CollegeProjekt/Abilities/MoreDamage", order = 0)]
public class MoreDamage : Ability
{
    [SerializeField]private Sprite origImg;
    [SerializeField]private Sprite image;
    public override void Activate()
    {
        base.Activate();
        //Glow player
        player.GetComponent<SpriteRenderer>().sprite = image;
        player.GetComponent<SpriteRenderer>().color = Color.white;
        player.GetComponent<PlayerStats>().SetPowerupMultiplier(2);
    }

    public override void Deactivate()
    {
        player.GetComponent<SpriteRenderer>().sprite = origImg;
        player.GetComponent<SpriteRenderer>().color = Color.red;
        player.GetComponent<PlayerStats>().SetPowerupMultiplier(1);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
