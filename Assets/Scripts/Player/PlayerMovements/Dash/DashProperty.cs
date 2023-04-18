using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DashProperty", menuName = "CollegeProjekt/DashProperty", order = 0)]
public class DashProperty : ScriptableObject {
    //Defines the dashing property. How much speed to take, how long the dash will last etc etc
    public string dashName;
    public float dashForce, maxDashSpeed;
    public float duration;
    public int framesForMaxCharge;
    public float maxExtraSpeed, maxExtraForce;
    public bool isGoThrough;
    public Sprite dashIcon;
}
