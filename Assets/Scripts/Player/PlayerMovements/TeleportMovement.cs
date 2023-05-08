using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMovement : MonoBehaviour
{
    [SerializeField]private KeyCode teleportKey;
    private bool teleportActive = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(teleportKey)){
            teleportActive = !teleportActive;
        }
        if(teleportActive && Input.GetMouseButtonUp(0)){
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine(DisableTeleport());
        }
    }

    public bool IsTeleportActive(){
        return teleportActive;
    }

    IEnumerator DisableTeleport(){
        yield return new WaitForEndOfFrame();
        teleportActive = false;
    }
}
