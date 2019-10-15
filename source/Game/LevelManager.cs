using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Loads levels and keeps score

public class LevelManager : MonoBehaviour {

    private static LevelManager instance;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(LevelManager)) as LevelManager;
            }
            
            return instance;
        }
    }

    private Scene currentScene;

    public int MovesMade { get; set; }

    void Start ()
    {
        currentScene = SceneManager.GetActiveScene();
        MovesMade++;
        Player.OnFireJetPack += updateMovesCount;
    }

    private void updateMovesCount()
    {
        MovesMade++;
    }

    void Update()
    {
        if (Input.GetButton("Retry"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(currentScene.buildIndex, LoadSceneMode.Single);
        }

        if (Input.GetButton("Menu"))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    public void LoadNext()
    {
        Time.timeScale = 1;

        if (currentScene.buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1, LoadSceneMode.Single);
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene.buildIndex, LoadSceneMode.Single);
    }
}
