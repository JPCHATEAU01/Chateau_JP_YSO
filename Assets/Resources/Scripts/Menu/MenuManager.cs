using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text title;
    public Text version;
    public GameObject panelPlay;

    void Start()
    {
        AudioManager.Instance().PlayIntro();
        title.text = GameManager.Instance().GetTitle();
        version.text = GameManager.Instance().GetVersion();
        DesactivatePanelPlay();
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

    public void QuitApp()
    {
        GameManager.Instance().QuitApp();
    }

    public void DisplayOption()
    {
        OptionManager.Instance().ActivateGameObject();
    }

}