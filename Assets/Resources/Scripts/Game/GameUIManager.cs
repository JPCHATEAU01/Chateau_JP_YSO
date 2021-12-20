using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Button optionButton;
    public Slider avancementSlider;
    public GameObject panelEnd;
    public Image handleImage;
    public Text victory;
    public Text defeat;
    public Button returnMenuButton;
    // Start is called before the first frame update
    void Awake()
    {
        LevelManager.Instance().SetGameUIManager(this);
        optionButton.onClick.AddListener(Pause);
        LevelManager.Instance().SetHandleImage(); 
        LevelManager.Instance().DiplayLevel(GameManager.Instance().GetLevelToLoad());
        AudioManager.Instance().PlayCredits();
        defeat.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        panelEnd.gameObject.SetActive(false);
    }

    private void Pause()
    {
        OptionManager.Instance().ActivateGameObject();
    }

    public void SetLogo(Sprite sprite)
    {
        handleImage.sprite = sprite;
    }

    public void End(bool isVictory)
    {
        panelEnd.gameObject.SetActive(true);
        if (isVictory)
        {
            victory.gameObject.SetActive(true);
        }
        else
        {
            defeat.gameObject.SetActive(true);
        }
    }

    public void UpdateSlider(float pos, float finalPos)
    {
        avancementSlider.maxValue = finalPos;
        float amount = (float)pos / finalPos;
        avancementSlider.value = pos;
    }

    public void ReturnMenu()
    {
        GameManager.Instance().LaunchScene("MenuScene");
    }
}