using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadDataIntoJsonFromResources<T>
{
    private string path;
    private TextAsset textJSON;
    private string file;

    public SaveLoadDataIntoJsonFromResources(string file)
    {
        this.file = file;
    }

    public void SaveIntoJson(T objectToSave)
    {
        //Debug.Log("save" + objectToSave.ToString());
        //string objectString = JsonUtility.ToJson(objectToSave);
        //Debug.Log("in memory" + objectString);
        //System.IO.File.WriteAllText(path + Path.DirectorySeparatorChar + file, objectString);
        //Debug.Log("save in " + Application.persistentDataPath + " text " + objectString);
    }

    public T LoadObject()
    {
        T ObjectToLoad;
        try
        {
            textJSON = Resources.Load<TextAsset>("Data" + Path.DirectorySeparatorChar + file);
            ObjectToLoad = JsonUtility.FromJson<T>(textJSON.text);
        }catch(Exception)
        {
            throw new Exception("SaveDataIntoJsonFromResources_LoadObject error file : " + file + " doesn't exist");
        }
        return ObjectToLoad;
    }

}