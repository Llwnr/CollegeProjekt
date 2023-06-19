using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightShadowTrigger : MonoBehaviour
{
    [SerializeField]private FlightShadowInGround shadowHeightManager;

    private float yPrev;
    [SerializeField]private bool activateFlight = false;

    private void Start() {
        yPrev = transform.position.y;
    }


    public void SetFlightActive(bool value){
        activateFlight = value;
    }
}
