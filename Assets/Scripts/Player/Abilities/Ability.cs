using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public new string name {get; private set;}
    public string description{get; private set;}
    
    protected AbilityManager abilityManager;
    protected GameObject player;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
        abilityManager = GameObject.FindWithTag("Player").GetComponent<AbilityManager>();
    }

    //Subscribe or unsubscribe to ability manager
    public virtual void OnEnable(){
        abilityManager.AddAbility(this);
    }
    public virtual void OnDisable() {
        abilityManager.RemoveAbility(this);
    }

    public abstract void Activate();
    public abstract void Deactivate();
}
