using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : BaseHealthManager, IDamagable
{
    public void DealDamage(float dmgAmt)
    {
        hp -= dmgAmt;
        NotifyObservers(dmgAmt, transform);
        if(hp < 0){
            gameObject.SetActive(false);
            NotifyMyDeath();
        }
    }
}
