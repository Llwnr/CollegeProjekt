using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour, IOnDeath
{
    [SerializeField]private GameObject itemToDrop;
    [SerializeField]private List<ItemBase> itemData;
    private BaseHealthManager healthManager;
    private void Awake() {
        healthManager = GetComponent<BaseHealthManager>();
        healthManager.AddObserver(this);
    }
    public void OnDeath()
    {
        int randomindex = Random.Range(0,itemData.Count);
        //Create the dummy gameobject and give it the script as well as graphics
        GameObject newItem = Instantiate(itemToDrop, transform.position, Quaternion.identity);
        newItem.GetComponent<SpriteRenderer>().sprite = itemData[randomindex].icon;
        newItem.GetComponent<ItemActivator>().SetItemToExecute(itemData[randomindex]);

        healthManager.RemoveObserver(this);
    }
}
