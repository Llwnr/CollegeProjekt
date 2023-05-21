using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHealthManager : MonoBehaviour
{
    [SerializeField]protected float hp;
    protected float maxHp;

    private void Awake() {
        maxHp = hp;
    }

    public float GetCurrentHp(){
        return hp;
    }
    public float GetMaxHp(){
        return maxHp;
    }


    //OBSERVER pattern
    protected List<IOnDamage> observers = new List<IOnDamage>();
    protected List<IOnDeath> deathObservers = new List<IOnDeath>();

    //Observers that act when target's health is damaged
    public void AddObserver(IOnDamage observer){
        observers.Add(observer);
    }
    public void RemoveObserver(IOnDamage observer){
        observers.Remove(observer);
    }

    //Observers that act when target is dead
    public void AddObserver(IOnDeath observer){
        deathObservers.Add(observer);
    }
    public void RemoveObserver(IOnDeath observer){
        deathObservers.Remove(observer);
    }

    public void NotifyObservers(float dmgAmt, Transform myTransform){
        for(int i=0; i<observers.Count; i++){
            observers[i].ActivateWhenDamaged(dmgAmt, myTransform);
        }
    }
    public void NotifyMyDeath(){
        for(int i=0; i<deathObservers.Count; i++){
            deathObservers[i].OnDeath();
        }
    }
}
