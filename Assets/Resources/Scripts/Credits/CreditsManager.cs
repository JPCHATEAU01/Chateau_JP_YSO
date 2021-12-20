using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public Animator animator;
    public Text title;
    public Button optionButton;
    private bool isPaused = false;
    void Start()
    {
        AudioManager.Instance().PlayCredits();
        optionButton.onClick.AddListener(Pause);
        title.text = GameManager.Instance().GetTitle();
    }

    void Update()
    {
        if (isPaused)
        {
            if (!GameManager.Instance().GetPaused())
            {
                isPaused = false;
                PlayAnimation();
            }
        }
    }

    public void LaunchMenu()
    {
        GameManager.Instance().LaunchScene("MenuScene");
    }

    private void Pause()
    {
        OptionManager.Instance().ActivateGameObject();
        PauseAnimation();
    }
    public void PauseAnimation()
    {
        animator.speed = 0;
        isPaused = true;
    }

    public void PlayAnimation()
    {
        animator.speed = 1;
    }

}