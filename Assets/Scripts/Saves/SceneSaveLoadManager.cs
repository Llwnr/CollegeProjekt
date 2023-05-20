using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaveLoadManager : MonoBehaviour
{
    [SerializeField]private List<ISaveable> mySaves = new List<ISaveable>();
    // Start is called before the first frame update
    void Start()
    {   
        CollectAllSaveableClass();
        //Don't load data on first level
        if(SceneManager.GetActiveScene().name == "Lvl1") return;
        //Load all data on start
        foreach(ISaveable saves in mySaves){
            saves.Load();
        }
    }

    private void OnDestroy() {
        //Save data on destroy
        foreach(ISaveable saves in mySaves){
            saves.Save();
        }
    }

    void CollectAllSaveableClass(){
        GameObject[] allObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach(GameObject eachObject in allObjects){
            foreach(ISaveable saveable in eachObject.GetComponentsInChildren<ISaveable>()){
                mySaves.Add(saveable);
            }
        }
    }
}
