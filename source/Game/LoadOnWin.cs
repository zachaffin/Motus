using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Shows win screen on level completion

public class LoadOnWin : MonoBehaviour {

    private CanvasGroup winGroup;

    private void Awake()
    {
        winGroup = GameObject.Find("WinGroup").GetComponent<CanvasGroup>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0.5f;
            winGroup.interactable = winGroup.blocksRaycasts = true;
            StartCoroutine(Fade.FadeIn(winGroup));
        }
    }
}
