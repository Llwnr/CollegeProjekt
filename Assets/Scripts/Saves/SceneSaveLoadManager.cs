using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneSaveLoadManager : MonoBehaviour
{
    [SerializeField]private List<ISaveable> mySaves = new List<ISaveable>();

    private void Awake() {
        //Check if the save direction exists otherwise create it
        if(!Directory.Exists(ISaveable.baseSaveLocation)){
            Directory.CreateDirectory(ISaveable.baseSaveLocation);
        }
    }
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

    private void OnDisable() {
        //Save data on destroy
        foreach(ISaveable saves in mySaves){
            if(saves == null) continue;
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
