using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInClue : MonoBehaviour
{
    public Image UI;

    void Start()
    {
        UI.canvasRenderer.SetAlpha(0.0f);
        FadeIn();
    }

    public void FadeIn() {
        UI.CrossFadeAlpha(1f, 0.2f, false);
    }

    public void FadeOutClue() {
        UI.CrossFadeAlpha(0f, 0.2f, false);
    }
}
