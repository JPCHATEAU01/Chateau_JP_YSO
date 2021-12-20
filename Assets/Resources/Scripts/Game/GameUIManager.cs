using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Button optionButton;
    public Slider avancementSlider;
    public Image handleImage;
    // Start is called before the first frame update
    void Awake()
    {
        LevelManager.Instance().SetGameUIManager(this);
        optionButton.onClick.AddListener(Pause);
        LevelManager.Instance().SetHandleImage(); 
        LevelManager.Instance().DiplayLevel("Level1");
    }

    private void Pause()
    {
        OptionManager.Instance().ActivateGameObject();
    }

    public void SetLogo(Sprite sprite)
    {
        handleImage.sprite = sprite;
    }

}