using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Handles button behavior when moused over

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private float baseY;
    private float targetY;
    private Image panel;

	void Start () {
        baseY = transform.position.y;
        targetY = baseY + 10;
        panel = transform.GetChild(0).GetComponent<Image>();
	}
	
	public void OnPointerEnter(PointerEventData eventData)
    {
        StopCoroutine("UnHighlightButton");
        StartCoroutine("HighlightButton");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine("HighlightButton");
        StartCoroutine("UnHighlightButton");
    }

    IEnumerator HighlightButton()
    {
        while (targetY - transform.position.y > 0.01f)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetY, 0.5f), transform.position.z);
            panel.CrossFadeAlpha(3f, 0.2f, true);
            yield return null;
        }
    }

    IEnumerator UnHighlightButton()
    {
        while (transform.position.y - baseY > 0.01f)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, baseY, 0.5f), transform.position.z);
            panel.CrossFadeAlpha(1f, 0.2f, true);
            yield return null;
        }
    }
}
