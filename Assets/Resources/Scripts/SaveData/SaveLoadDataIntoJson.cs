using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadDataIntoJson<T>
{
    private string path;
    private string file;

    public SaveLoadDataIntoJson(string file)
    {
        this.path = Application.persistentDataPath;
        this.file = file;
    }

    public void SaveIntoJson(T objectToSave)
    {
        //Debug.Log("save" + objectToSave.ToString());
        string objectString = JsonUtility.ToJson(objectToSave);
        //Debug.Log("in memory" + objectString);
        System.IO.File.WriteAllText(path + Path.DirectorySeparatorChar + file, objectString);
        //Debug.Log("save in " + Application.persistentDataPath + " text " + objectString);
    }

    public T LoadObject()
    {
        string saveFile = path + Path.DirectorySeparatorChar + file;
        T ObjectToLoad;
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);
            ObjectToLoad = JsonUtility.FromJson<T>(fileContents);
        }
        else
        {
            throw new Exception("SaveDataIntoJson_LoadObject error file : " + file + " doesn't exist");
        }
        return ObjectToLoad;
    }

}