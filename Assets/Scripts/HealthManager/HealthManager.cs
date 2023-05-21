using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HealthManager : MonoBehaviour, IDamagable, ISaveable
{
    [SerializeField]private float hp;
    private float maxHp;

    private int dmgReduction;

    [SerializeField]private bool isImmune = false;
    public void SetDmgReduction(float value){
        dmgReduction = (int)value;
    }

    public void SetDmgImmunity(bool value){
        isImmune = value;
    }

    //Observer pattern.
    //Subscribers are: DmgPopup
    private List<IOnDamage> observers = new List<IOnDamage>();
    private List<IOnDeath> deathObservers = new List<IOnDeath>();

    public void AddObserver(IOnDamage observer){
        observers.Add(observer);
    }
    public void RemoveObserver(IOnDamage observer){
        observers.Remove(observer);
    }
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


    void Awake()
    {
        maxHp = hp;
    }

    public void DealDamage(float dmgAmt){
        //Don't deal damage when player is immune
        if(isImmune){
            return;
        }

        float newDmgAmt = dmgAmt - dmgReduction;
        newDmgAmt = (int)newDmgAmt;
        //Don't notify subscribers of player taking 0 damage
        if(newDmgAmt < 1f) return;
        hp -= newDmgAmt;
        NotifyObservers(newDmgAmt, transform);
        if(hp < 0){
            gameObject.SetActive(false);
            NotifyMyDeath();
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


    //SAVE LOAD SYSTEM
    private SaveObject mySave;
    private string mySaveJson;
    public void Save()
    {
        //Don't save enemies hp
        if(transform.tag != "Player") return;
        //Don't save player's hp if player just died
        if(hp < 0) return;
        mySave = new SaveObject();
        mySave.hp = hp;

        mySaveJson = JsonUtility.ToJson(mySave);
        File.WriteAllText(ISaveable.baseSaveLocation + "healthSave.txt", mySaveJson);
    }

    public void Load()
    {
        if(transform.tag != "Player") return;
        SaveObject myLoad = JsonUtility.FromJson<SaveObject>(File.ReadAllText(ISaveable.baseSaveLocation+"healthSave.txt"));
        hp = myLoad.hp;
    }

    private class SaveObject{
        public float hp;
    }
}
