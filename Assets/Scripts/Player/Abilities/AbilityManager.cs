using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField]private List<Ability> abilities;
    public void AddAbility(Ability ability){
        abilities.Add(ability);
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
