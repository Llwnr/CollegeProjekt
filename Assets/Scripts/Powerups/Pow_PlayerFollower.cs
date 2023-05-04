using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallRotateAroundPlayer", menuName = "CollegeProjekt/Powerups/BallRotate", order = 0)]
public class Pow_PlayerFollower : Powerup
{
    [SerializeField]private GameObject ballToRotate;
    public float rotateSpeed;
    private GameObject ball;
    public override void Activate()
    {
        base.Activate();
        ball = Instantiate(ballToRotate, Vector3.zero, Quaternion.identity);
        ball.transform.SetParent(player.transform, false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        ball.transform.Rotate(new Vector3(0,0,rotateSpeed), Space.Self);
    }

    public override void Deactivate()
    {
        ball.SetActive(false);
    }
}
