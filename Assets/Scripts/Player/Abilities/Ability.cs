using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {
    public new string name {get; private set;}
    public string description{get; private set;}
    
    protected AbilityManager abilityManager;
    protected GameObject player;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
        abilityManager = GameObject.FindWithTag("Player").GetComponent<AbilityManager>();
    }

    public abstract void OnUpdate();

    public abstract void Activate();
    public abstract void Deactivate();
}
