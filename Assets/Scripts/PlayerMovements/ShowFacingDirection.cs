using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFacingDirection : MonoBehaviour
{
    [SerializeField]private float lineLength;
    private float hDir, vDir;

    // Update is called once per frame
    void Update()
    {
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position+new Vector3(0.5f,0,0), transform.position+new Vector3(0.5f,0,0) + new Vector3(hDir, vDir)*3f);
        Gizmos.DrawLine(transform.position-new Vector3(0.5f,0,0), transform.position-new Vector3(0.5f,0,0) + new Vector3(hDir, vDir)*3f);
        Gizmos.DrawLine(transform.position+new Vector3(0,0.5f,0), transform.position+new Vector3(0,0.5f,0) + new Vector3(hDir, vDir)*3f);
        Gizmos.DrawLine(transform.position-new Vector3(0,0.5f,0), transform.position-new Vector3(0,0.5f,0) + new Vector3(hDir, vDir)*3f);
    }
}
