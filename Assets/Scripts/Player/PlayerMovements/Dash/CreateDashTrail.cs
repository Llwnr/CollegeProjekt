using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDashTrail : MonoBehaviour, IDashObserver
{
    [SerializeField]private float interval;
    private float intervalCount;
    [SerializeField]private GameObject trail;

    private bool activate = false;

    private void Start() {
        GetComponent<BallDash>().AddDashObserver(this);
    }

    public void DashStart()
    {
        activate = true;
        intervalCount = interval;
    }

    public void DashEnd()
    {
        activate = false;
    }

    private void Update() {
        //Create trail object at given intervals
        if(activate){
            intervalCount -= Time.deltaTime;
            if(intervalCount < 0){
                Instantiate(trail, transform.position+new Vector3(0,0,2), Quaternion.identity);
                intervalCount = interval;
            }
        }
    }
}
