using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private string tilte = "TITRE";
    private string version = "0.0.2";
    private bool isPaused = false;

    public string GetVersion()
    {
        return version;
    }

    public string GetTitle()
    {
        return tilte;
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

    public void SetPaused(bool paused)
    {
        isPaused = paused;
    }

    public bool GetPaused()
    {
        return isPaused;
    }


}