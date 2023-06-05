using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UhhConvertToPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.GetChild(0).position;
        transform.GetChild(0).localPosition = Vector3.zero;
        transform.GetChild(0).GetComponent<Rigidbody2D>().velocity *= 0.985f;
    }
}
