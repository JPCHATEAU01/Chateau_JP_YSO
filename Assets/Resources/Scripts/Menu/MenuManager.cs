using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text title;
    public Text version;
    public GameObject panelPlay;
    public List<Button> LevelDif;

    void Start()
    {
        AudioManager.Instance().PlayIntro();
        title.text = GameManager.Instance().GetTitle();
        version.text = GameManager.Instance().GetVersion();
        DesactivatePanelPlay();
        foreach(Button button in LevelDif)
        {
            button.interactable = false;
        }
        MakeButtonDif();
    }

    public void LaunchCredits()
    {
        GameManager.Instance().LaunchScene("CreditsScene");
    }

    public void ActivatePanelPlay()
    {
        panelPlay.SetActive(true);
    }

    public void DesactivatePanelPlay()
    {
        panelPlay.SetActive(false);
    }

    public void LaunchGame(string level)
    {
        GameManager.Instance().SetLevelToLoad(level);
        GameManager.Instance().LaunchScene("PlayScene");
    }
    public void LaunchGameDif(int dif = 0)
    {
        GameManager.Instance().SetDif(dif);
    }

    public void QuitApp()
    {
        GameManager.Instance().QuitApp();
    }

    public void DisplayOption()
    {
        OptionManager.Instance().ActivateGameObject();
    }

    public void MakeButtonDif()
    {
        Account account = GameManager.Instance().GetAccount();
        //TODO
        if(account.GetDif()[0] == 1)
        {
            LevelDif[0].interactable = true;
        }
        if (account.GetDif()[0] == 2)
        {
            LevelDif[0].interactable = true;
            LevelDif[1].interactable = true;
        }
        if (account.GetDif()[1] == 1)
        {
            LevelDif[2].interactable = true;
        }
        if (account.GetDif()[1] == 2)
        {
            LevelDif[2].interactable = true;
            LevelDif[3].interactable = true;
        }
    }
}