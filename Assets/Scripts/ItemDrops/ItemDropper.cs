using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour, IOnDeath
{
    [SerializeField]private GameObject itemToDrop;
    [SerializeField]private ItemBase itemData;
    private HealthManager healthManager;
    private void Awake() {
        healthManager = GetComponent<HealthManager>();
        healthManager.AddObserver(this);
    }
    public void OnDeath()
    {
        Debug.Log("Drop new item");
        //Create the dummy gameobject and give it the script as well as graphics
        GameObject newItem = Instantiate(itemToDrop, transform.position, Quaternion.identity);
        newItem.GetComponent<SpriteRenderer>().sprite = itemData.icon;
        newItem.GetComponent<ItemActivator>().SetItemToExecute(itemData);

        healthManager.RemoveObserver(this);
    }
}
