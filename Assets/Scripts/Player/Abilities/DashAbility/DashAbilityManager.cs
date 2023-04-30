using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbilityManager : MonoBehaviour, IDashObserver
{
    private BallDash ballDash;
    private DashAbility dashAbilityToGive;

    [SerializeField]private List<DashAbility> dashAbilities = new List<DashAbility>();

    private void Update() {
        // if(dashAbilityToGive == null || dashAbilityToGive != ballDash.GetDashAbility()){
        //     dashAbilityToGive = ballDash.GetDashAbility();
        //     dashAbilities.Clear();
        //     AddDashAbility(dashAbilityToGive);
        // }
    }
    
    private void Awake() {
        ballDash = GetComponent<BallDash>();
        //Subscribe to ball dash to get notified when ball dashes and ends dash
        ballDash.AddDashObserver(this);
    }
    
    public void AddDashAbility(DashAbility dashAbility){
        dashAbilities.Add(dashAbility);
    }

    public void RemoveDashAbility(DashAbility dashAbility){
        dashAbilities.Remove(dashAbility);
        dashAbility.Deactivate();
    }

    //Activate all dash abilities when player is dashing
    public void DashStart(){
        foreach(DashAbility dashAbility in dashAbilities){
            dashAbility.Activate();
        }
    }

    //Deactivate dash abilities when player is not dashing
    public void DashEnd(){
        foreach(DashAbility dashAbility in dashAbilities){
            dashAbility.Deactivate();
        }
    }


}
