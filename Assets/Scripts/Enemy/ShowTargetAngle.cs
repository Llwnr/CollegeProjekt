using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTargetAngle : MonoBehaviour
{
    public float angle;
    public Vector2 dirNew;
    private Transform player;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = player.position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + offset;
        dirNew = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
    }
}
