using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDashCharge : MonoBehaviour
{
    [SerializeField]private Image chargeBar;
    private BallDash ballDash;
    private float maxCharge, currCharge;
    // Start is called before the first frame update
    private void Start() {
        ballDash = GetComponent<BallDash>();
        maxCharge = ballDash.GetMaxCharge();
    }

    // Update is called once per frame
    void Update()
    {
        currCharge = ballDash.GetCurrentCharge();
        chargeBar.fillAmount = currCharge/maxCharge;
    }
}
