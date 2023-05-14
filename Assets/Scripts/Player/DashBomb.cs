using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBomb : MonoBehaviour, IDashObserver
{
    [SerializeField]private GameObject dashBomb;
    private BallDash ballDash;

    private void Start() {
        ballDash = GetComponent<BallDash>();
        ballDash.AddDashObserver(this);
    }

    private void OnDestroy() {
        ballDash.RemoveDashObserver(this);
    }
    
    public void DashStart(){
        //Time.timeScale = 0.02f;
        dashBomb.SetActive(true);
        StartCoroutine(Deactivate());
    }

    IEnumerator Deactivate(){
        yield return new WaitForFixedUpdate();
        dashBomb.SetActive(false);
    }

    public void DashEnd(){
        Time.timeScale = 1;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            Time.timeScale = 0.01f;
        }
    }
}
