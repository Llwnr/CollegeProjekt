using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField]private bool isPlayer = false;
    [SerializeField]private float offset = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(isPlayer){
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position - transform.position;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0, angle-90 + offset);
    }
}
