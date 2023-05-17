using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IframesColDetection : MonoBehaviour
{
    private RaycastHit2D[] hits;
    private Rigidbody2D rb;

    [SerializeField]private Vector3 prevPos = Vector3.zero;
    [SerializeField]private Vector3 curPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Since sometimes trigger is ignored when ball moves too fast, raycast the distance travelled by ball and see if it hits the bullets
        Vector2 dir = transform.position - prevPos;
        hits = Physics2D.RaycastAll(prevPos, dir, Vector2.Distance(transform.position, prevPos));
        for(int i=0; i<hits.Length; i++){
            if(hits[i].collider != null && hits[i].transform.CompareTag("Projectile")){
                hits[i].transform.GetComponent<DamagePlayer>().RaycastTriggered(gameObject);
            }
        }
        prevPos = transform.position;
    }
}
