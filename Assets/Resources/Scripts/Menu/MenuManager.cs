using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text version;
    // Start is called before the first frame update
    void Start()
    {
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

}
