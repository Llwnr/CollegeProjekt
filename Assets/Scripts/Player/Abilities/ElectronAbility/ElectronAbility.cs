using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElectronAbility : ScriptableObject
{
    public new string name;
    [TextArea (3,10)]
    public string description;
    
    //References
    protected GameObject player;

    protected void GetReferences() {
        player = GameObject.FindWithTag("Player");
    }

    public virtual void Activate(){
        GetReferences();
    }

    public abstract void Deactivate();
}
