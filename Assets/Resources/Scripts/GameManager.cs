using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private string tilte;
    private string version;
    private bool isPaused;

    protected override void Awake()
    {
        base.Awake();
        tilte = Application.productName;
        version = Application.version;
        isPaused = false;
    }

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
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public bool GetPaused()
    {
        return isPaused;
    }


}