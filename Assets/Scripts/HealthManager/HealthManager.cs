using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamagable
{
    [SerializeField]private float hp;
    private float maxHp;

    private bool isInvincible = false;
    public void SetInvincible(bool value){
        isInvincible = value;
    }

    //Observer pattern.
    //Subscribers are: DmgPopup
    private List<IOnDamage> observers = new List<IOnDamage>();

    public void AddObserver(IOnDamage observer){
        observers.Add(observer);
    }
    public void RemoveObserver(IOnDamage observer){
        observers.Remove(observer);
    }

    public void NotifyObservers(float dmgAmt, Transform myTransform){
        for(int i=0; i<observers.Count; i++){
            observers[i].ActivateWhenDamaged(dmgAmt, myTransform);
        }
    }


    void Awake()
    {
        maxHp = hp;
    }

    public void DealDamage(float dmgAmt){
        if(isInvincible){
            return;
        }
        hp -= dmgAmt;
        NotifyObservers(dmgAmt, transform);
        if(hp < 0){
            gameObject.SetActive(false);
        }
    }

    public float GetCurrentHp(){
        return hp;
    }
    public float GetMaxHp(){
        return maxHp;
    }

    public void Heal(float healAmt){
        hp += healAmt;
        if(hp > maxHp) hp = maxHp;
    }
}
