using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DashProperty", menuName = "CollegeProjekt/DashProperty", order = 0)]
public class DashProperty : ScriptableObject {
    public string dashName;
    public float dashForce, maxDashSpeed;
    public float duration;
    public int framesForMaxCharge;
    public float maxExtraSpeed, maxExtraForce;
    public bool isGoThrough;
}
