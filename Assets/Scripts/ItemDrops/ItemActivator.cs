using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    private ItemBase itemToExecute;
    [SerializeField]private float invulnerabilityFrames;
    
    public void SetItemToExecute(ItemBase item){
        itemToExecute = item;
    }

    private void Update() {
        invulnerabilityFrames -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(invulnerabilityFrames <= 0 && other.transform.CompareTag("Player")){
            itemToExecute.ActivateOnCollision();
            gameObject.SetActive(false);
        }
    }
}
