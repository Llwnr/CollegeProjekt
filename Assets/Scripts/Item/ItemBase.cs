using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    public new string name;
    [TextArea (3,8)]
    public string description;
    public Sprite icon;

    protected GameObject player;
    private void OnEnable() {
        player = GameObject.FindWithTag("Player");
    }
    public abstract void ActivateOnCollision();
}
