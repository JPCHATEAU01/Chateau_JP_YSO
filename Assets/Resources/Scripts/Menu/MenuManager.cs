using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text title;
    public Text version;
    
    void Start()
    {
        AudioManager.Instance().PlayIntro();
        title.text = GameManager.Instance().GetTitle();
        version.text = GameManager.Instance().GetVersion();
    }

    public void LaunchCredits()
    {
        GameManager.Instance().LaunchScene("CreditsScene");
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