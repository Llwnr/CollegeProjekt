using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class Blast : ActionNode
{
    public GameObject blastExplosion;
    private Transform myTransform, player;
    protected override void OnStart() {
        player = GameObject.FindWithTag("Player").transform;
        myTransform = context.transform;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        Debug.Log("Blasted");
        myTransform.gameObject.SetActive(false);
        return State.Success;
    }
}
