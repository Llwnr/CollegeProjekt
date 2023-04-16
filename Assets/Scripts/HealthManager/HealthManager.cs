using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamagable
{
    [SerializeField]private float hp;
    private float maxHp;
    // Start is called before the first frame update
    void Awake()
    {
        maxHp = hp;
    }

    public void DealDamage(float dmgAmt){
        hp -= dmgAmt;
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
}
