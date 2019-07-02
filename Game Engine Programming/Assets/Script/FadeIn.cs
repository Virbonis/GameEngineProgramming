using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fadeInTarget;

    void Start()
    {
        fadeInTarget.canvasRenderer.SetAlpha(0.0f);
        Fadein();
    }

    public void Fadein() {
        fadeInTarget.CrossFadeAlpha(1f, 0.15f, false);
        SoundManager.PlaySound("Note Pickup");
    }

    public void FadeOut()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait() {
        SoundManager.PlaySound("Gain Knowledge");
        fadeInTarget.CrossFadeAlpha(0f, 0.15f, false);
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
