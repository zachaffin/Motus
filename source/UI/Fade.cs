using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fades the screen in and out

public static class Fade{

    public static IEnumerator FadeOut(CanvasGroup toFade)
    {
        toFade.alpha = 1;
        while (toFade.alpha > 0)
        {
            toFade.alpha -= Time.deltaTime * 2;
            yield return null;
        }
    }

    public static IEnumerator FadeIn(CanvasGroup toFade)
    {
        toFade.alpha = 0;
        while (toFade.alpha < 1)
        {
            toFade.alpha += Time.deltaTime * 2;
            yield return null;
        }
    }
}
