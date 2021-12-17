using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private string version = "0.0.2";

    public string GetVersion()
    {
        return version;
    }

    public void LaunchScene(string sceneName)
    {
        LevelLoader.Instance().LoadScreen(sceneName);
    }

    public void QuitApp()
    {
        Debug.Log("QuitApp");
        Application.Quit();
    }

}