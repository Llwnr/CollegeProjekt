using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveElectricChargeOnDash : MonoBehaviour, IDashObserver
{
    [SerializeField]private ParticleSystem electricDischarge;

    private void Start() {
        electricDischarge.Stop();
        GetComponent<BallDash>().AddDashObserver(this);
    }

    public void DashEnd()
    {
        electricDischarge.Stop();
    }

    public void DashStart()
    {
        electricDischarge.Play();
    }
}
