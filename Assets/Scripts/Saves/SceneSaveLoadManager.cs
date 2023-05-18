using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSaveLoadManager : MonoBehaviour
{
    [SerializeField]private List<ISaveable> mySaves = new List<ISaveable>();
    // Start is called before the first frame update
    void Start()
    {   
        CollectAllSaveableClass();
    }

    // Update is called once per frame
    void Update()
    {
        //Save everything
        if(Input.GetKeyDown(KeyCode.Q)){
            foreach(ISaveable saves in mySaves){
                saves.Save();
            }
        }
        if(Input.GetKeyDown(KeyCode.E)){
            foreach(ISaveable saves in mySaves){
                saves.Load();
            }
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
