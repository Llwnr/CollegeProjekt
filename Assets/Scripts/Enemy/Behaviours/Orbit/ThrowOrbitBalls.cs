using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ThrowOrbitBalls : ActionNode
{
    public float throwForce;
    protected override void OnStart() {
    }

    protected override void OnStop() {
        for(int i=0; i<blackboard.orbitBalls.Count; i++){
            blackboard.orbitBalls[i].transform.parent = null;
        }
        blackboard.orbitBalls.Clear();
        GameObject.Destroy(blackboard.orbitPivot.gameObject);
    }

    protected override State OnUpdate() {
        foreach(GameObject ball in blackboard.orbitBalls){
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            rb.AddForce((GameObject.FindWithTag("Player").transform.position - ball.transform.position).normalized*throwForce, ForceMode2D.Impulse);
            Debug.Log("Force added");
        }

        return State.Success;
    }
}