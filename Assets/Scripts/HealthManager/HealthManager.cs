using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HealthManager : BaseHealthManager, IDamagable, ISaveable
{
    private int dmgReduction;

    [SerializeField]private bool isImmune = false;
    public void SetDmgReduction(float value){
        dmgReduction = (int)value;
    }

    public void SetDmgImmunity(bool value){
        isImmune = value;
    }

    public void DealDamage(float dmgAmt){
        //Don't deal damage when player is immune
        if(isImmune){
            GetComponent<DmgPopupManager>().ActivateWhenDamaged("ABSORBED", transform);
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

    public void Heal(float healAmt){
        hp += healAmt;
        if(hp > maxHp) hp = maxHp;
    }


    //SAVE LOAD SYSTEM
    private SaveObject mySave;
    private string mySaveJson;
    public void Save()
    {
        //Don't save player's hp if player just died
        if(hp < 0) return;
        mySave = new SaveObject();
        mySave.hp = hp;

        mySaveJson = JsonUtility.ToJson(mySave);
        File.WriteAllText(ISaveable.baseSaveLocation + "healthSave.txt", mySaveJson);
    }

    public void Load()
    {
        SaveObject myLoad = JsonUtility.FromJson<SaveObject>(File.ReadAllText(ISaveable.baseSaveLocation+"healthSave.txt"));
        hp = myLoad.hp;
    }

    private class SaveObject{
        public float hp;
    }
}
