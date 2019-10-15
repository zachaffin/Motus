using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Provides functions for buttons to call when clicked

public class LoadOnClick : MonoBehaviour {

    private CanvasGroup mainMenuGroup;
    private CanvasGroup levelSelectGroup;
    private CanvasGroup fadePanel;

    void Awake()
    {
        mainMenuGroup = transform.GetChild(0).Find("MainMenuGroup").GetComponent<CanvasGroup>();
        levelSelectGroup = transform.GetChild(0).Find("LevelSelectGroup").GetComponent<CanvasGroup>();
        fadePanel = transform.GetChild(0).Find("FadeOut").GetComponent<CanvasGroup>();
    }

    public void LoadScene(int level)
    {
        StartCoroutine(FadeTo(level));
    }

    public void LevelSelect()
    {
        StartCoroutine(FadeToLevelMenu());
    }

    public void MainMenu()
    {
        StartCoroutine(FadeToMainMenu());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator FadeTo(int level)
    {
        while (levelSelectGroup.alpha > 0)
        {
            levelSelectGroup.alpha -= Time.deltaTime * 2;
            fadePanel.alpha += Time.deltaTime * 2;
            yield return null;
        }
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    IEnumerator FadeToLevelMenu()
    {
        mainMenuGroup.interactable = mainMenuGroup.blocksRaycasts = false;
        levelSelectGroup.interactable = levelSelectGroup.blocksRaycasts = true;

        while (mainMenuGroup.alpha > 0)
        {
            mainMenuGroup.alpha -= Time.deltaTime * 4;
            levelSelectGroup.alpha += Time.deltaTime * 4;
            yield return null;
        }
    }

    IEnumerator FadeToMainMenu()
    {
        mainMenuGroup.interactable = mainMenuGroup.blocksRaycasts = true;
        levelSelectGroup.interactable = levelSelectGroup.blocksRaycasts = false;

        while (levelSelectGroup.alpha > 0)
        {
            mainMenuGroup.alpha += Time.deltaTime * 4;
            levelSelectGroup.alpha -= Time.deltaTime * 4;
            yield return null;
        }
    }
}
