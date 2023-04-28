using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DashAbility : ScriptableObject
{
    public new string name;
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
