using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Fades in a level

public class FadeOut : MonoBehaviour {

	void Start () {
        StartCoroutine(Fade.FadeOut(GetComponent<CanvasGroup>()));
	}
}
