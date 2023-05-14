using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField]private List<Ability> abilities;

    public void AddAbility(Ability ability){
        if(!ability.CanActivate()) return;
        if(!this.enabled) return;
        abilities.Add(ability);
        Debug.Log("Ability Given");
        ability.Activate();
    }

    public void RemoveAbility(Ability ability){
        abilities.Remove(ability);
        ability.Deactivate();
    }

    private void Update() {
        for(int i=0; i<abilities.Count; i++){
            abilities[i].OnUpdate();
        }
    }

    public List<Ability> GetMyAbilities(){
        return abilities;
    }
}
