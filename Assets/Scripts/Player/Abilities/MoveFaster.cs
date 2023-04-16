using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFaster : Ability
{
    [SerializeField]private float extraMoveSpeed;
    //Main function
    public override void Activate()
    {
        player.GetComponent<BallMovement>().SetExtraMoveSpeed(extraMoveSpeed);
        StartCoroutine(DeactivateSoon());
    }

    public override void Deactivate()
    {
        player.GetComponent<BallMovement>().SetExtraMoveSpeed(0);
        Debug.Log("Deactivated");
    }

    IEnumerator DeactivateSoon(){
        yield return new WaitForSeconds(3);
        Deactivate();
    }
}
