using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    public static string baseSaveLocation = Application.dataPath + "/saves/";
    void Save();
    void Load();
}
