using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private string tilte;
    private string version;
    private bool isPaused;
    private string levelToLoad = "Level2";
    private int dif = 0;
    private Account account;
    private SaveLoadDataIntoJson<Account> accountData;

    protected override void Awake()
    {
        base.Awake();
        tilte = Application.productName;
        version = Application.version;
        isPaused = false;
        LoadAccount();
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

    public string GetLevelToLoad()
    {
        return levelToLoad;
    }

    public void SetLevelToLoad(string levelToLoad)
    {
        this.levelToLoad = levelToLoad;
    }

    public int GetDif()
    {
        return dif;
    }

    public void SetDif(int dif)
    {
        this.dif = dif;
    }

    public void LoadAccount()
    {
        accountData = new SaveLoadDataIntoJson<Account>("Account.json");
        try
        {
            account = accountData.LoadObject();
        }
        catch (Exception)
        {
            account = new Account(null, null);
            Debug.Log(account);
            accountData.SaveIntoJson(account);
        }
    }

    public Account GetAccount()
    {
        return account;
    }

    public void SaveAccount(Account after)
    {
        account = after;
        accountData.SaveIntoJson(account);
    }
}