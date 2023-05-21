using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField]private BaseHealthManager targetHealth;
    private Image myHealth;

    [SerializeField]private float maxHp;
    // Start is called before the first frame update
    void Start()
    {
        myHealth = GetComponent<Image>();
        maxHp = targetHealth.GetMaxHp();
    }

    // Update is called once per frame
    void Update()
    {
        myHealth.fillAmount = targetHealth.GetCurrentHp()/maxHp;
    }
}
