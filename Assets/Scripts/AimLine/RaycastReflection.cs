using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastReflection : MonoBehaviour
{
    public int refelctions;
    public float maxLength;

    private LineRenderer lineRenderer;
    private List<Ray2D> rays = new List<Ray2D>();
    private Ray2D centralRay;
    private List<Vector3> offsets = new List<Vector3>();
    private RaycastHit2D hit;
    private Vector3 dir;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();

        for(int i=0; i<360; i++){
            //Points at outer radius of circle
            Vector3 pos = new Vector3();
            pos.x = (0.5f * Mathf.Cos(i / (180f / Mathf.PI)));
            pos.y = (0.5f * Mathf.Sin(i / (180f / Mathf.PI)));
            pos.z = -2;
            if(Vector2.Distance(new Vector2(0,0), pos) < 0.499f || Vector2.Distance(new Vector2(0,0), pos) > 0.501f){
                continue;
            }
            offsets.Add(pos);
        }
        Debug.Log(offsets.Count);
    }

    private void Update() {
        rays.Clear();
        //Offset rays to cover whole circle
        for(int i=0; i<offsets.Count; i++){
            rays.Add(new Ray2D(transform.position+offsets[i], Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position));
        }
        centralRay = new Ray2D(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position);
        //Set starting position
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        float remainingLength = maxLength;

        LayerMask enemyMask = LayerMask.GetMask("Enemy");

        

        for(int i=0; i<refelctions;  i++){
            if(hit = Physics2D.Raycast(centralRay.origin, centralRay.direction, remainingLength, enemyMask)){
                //If enemy is hit then reflect
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount-1, hit.point);
                remainingLength -= Vector2.Distance(centralRay.origin, hit.point);
                //Start a new ray and reflect it.
                //centralRay = new Ray2D(hit.point, Vector2.Reflect(centralRay.direction, hit.normal));
            }else{
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount-1, centralRay.origin+centralRay.direction*remainingLength);
            }
        }

        //To find out which ray will hit first
        float dist = 50000f;
        for(int i=0; i<rays.Count; i++){
            //Show the ray that hit an enemy
            if(hit = Physics2D.Raycast(rays[i].origin, rays[i].direction, remainingLength, enemyMask)){
                float currDist = Vector2.Distance(rays[i].origin, hit.point);
                if(currDist > dist) continue;
                dist = currDist;
                //Since distance may be NaN when theres no target(unity bug)
                if(currDist < 1000){
                    centralRay = new Ray2D(hit.point, Vector2.Reflect(rays[i].direction, hit.normal));
                    lineRenderer.positionCount = 1;
                    lineRenderer.SetPosition(0, rays[i].origin);
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount-1, hit.point);
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount-1, centralRay.origin+centralRay.direction*remainingLength);
                }
            }
        }    
    }
}
