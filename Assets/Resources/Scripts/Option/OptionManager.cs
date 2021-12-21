using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : Singleton<OptionManager>, IVisible
{
    public GameObject panelOption;
    public Slider musicSlider;
    public Toggle musicToggle;

    public void Start()
    {
        musicSlider.value = (int)(AudioManager.Instance().GetVolume() * 100);
    }

    public void ChangeSlider()
    {
        AudioManager.Instance().ChangeVolume(musicSlider.value / 100);
    }

    public void ActivateGameObject()
    {
        panelOption.gameObject.SetActive(true);
        GameManager.Instance().SetPaused(true);
    }

    public void DesactivateGameObject()
    {
        panelOption.gameObject.SetActive(false);
        GameManager.Instance().SetPaused(false);
    }

    public void PlayMusic()
    {
        bool isActivatedToggle = musicToggle.GetComponent<Toggle>().isOn;
        AudioManager.Instance().PlayMusic(isActivatedToggle);
    }
}