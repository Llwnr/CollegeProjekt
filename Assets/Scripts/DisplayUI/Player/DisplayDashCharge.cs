using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDashCharge : MonoBehaviour
{
    private Image chargeBar;
    private BallDash ballDash;
    private float maxCharge, currCharge;
    // Start is called before the first frame update
    private void Start() {
        ballDash = GameObject.FindWithTag("Player").GetComponent<BallDash>();
        chargeBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        maxCharge = ballDash.GetMaxCharge();
        currCharge = ballDash.GetCurrentCharge();
        chargeBar.fillAmount = currCharge/maxCharge;
        //chargeBar.color = ballDash.GetDashChargeBarColor();
    }
}
