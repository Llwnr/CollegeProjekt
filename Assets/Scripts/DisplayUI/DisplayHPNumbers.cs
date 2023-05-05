using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHPNumbers : MonoBehaviour
{
    private TextMeshProUGUI textBox;
    private HealthManager playerHealth;

    private void Start() {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<HealthManager>();
        textBox = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = playerHealth.GetCurrentHp() + " / " + playerHealth.GetMaxHp();
    }
}
