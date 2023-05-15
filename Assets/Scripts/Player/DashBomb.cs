using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBomb : MonoBehaviour, IDashObserver
{
    [SerializeField]private GameObject dashBomb;
    private Collider2D dashBombCollider;
    private SpriteRenderer spriteRenderer;
    private BallDash ballDash;

    private void Start() {
        ballDash = GetComponent<BallDash>();
        ballDash.AddDashObserver(this);
        dashBombCollider = dashBomb.GetComponent<Collider2D>();
        spriteRenderer = dashBomb.GetComponent<SpriteRenderer>();
    }

    private void OnDestroy() {
        ballDash.RemoveDashObserver(this);
    }
    
    public void DashStart(){
        //Time.timeScale = 0.02f;
        dashBombCollider.enabled = true;
        //Show the bomb at dash start
        spriteRenderer.enabled = true;
        //Don't move the dash bomb
        dashBomb.GetComponent<FollowObject>().enabled = false;
        StartCoroutine(Deactivate());
    }

    IEnumerator Deactivate(){
        yield return new WaitForSeconds(0.08f);
        dashBombCollider.enabled = false;
        spriteRenderer.enabled = false;
        dashBomb.GetComponent<FollowObject>().enabled = true;
    }

    public void DashEnd(){
    }
}
