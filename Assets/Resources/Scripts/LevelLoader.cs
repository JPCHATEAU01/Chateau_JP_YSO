using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Singleton<LevelLoader>, IVisible
{
    public Animator fadeAnimator;
    public Canvas canvas;
    private List<string> scenesName = new List<string>();
    private IEnumerator coroutine;
    private string sceneToLoad = null;
    private bool alreadyLoading = false;

    public void Start()
    {
        GetScenes();
        DesactivateGameObject();
    }

    public void LoadScreen(string sceneName)
    {
        if (!CheckScene(sceneName))
        {
            sceneName = scenesName[0];
        }
        sceneToLoad = sceneName;
        ActivateGameObject();
        fadeAnimator.SetTrigger("StartFadeIn");
    }

    public void LoadScene()
    {
        if (alreadyLoading)
        {
            return;
        }
        alreadyLoading = true;
        //Debug.Log("levelLoader_LoadScene");
        ActivateGameObject();
        coroutine = LoadAsyncScene(sceneToLoad);
        StartCoroutine(coroutine);
    }

    public IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        fadeAnimator.SetTrigger("StartFadeOut");
        alreadyLoading = false;
    }

    private bool CheckScene(string sceneName)
    {
        foreach (string nameScene in scenesName)
        {
            if (sceneName.Equals(nameScene))
            {
                return true;
            }
        }
        return false;
    }

    void GetScenes()
    {
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; i++)
        {
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
            scenesName.Add(sceneName);
        }
    }
    public void ActivateGameObject()
    {
        canvas.gameObject.SetActive(true);
    }

    public void DesactivateGameObject()
    {
        canvas.gameObject.SetActive(false);
    }

}