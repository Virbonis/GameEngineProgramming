using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouAreDead : MonoBehaviour
{
    public Image splashImage;
    private float timer = 3.75f;
    private Animator fontAnim;

    void Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        fontAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (DeathSceneFade.DeathFont == true)
        {
            StartCoroutine(Wait());
            DeathSceneFade.DeathFont = false;
        }
    }

    public void FadeIn()
    {
        splashImage.CrossFadeAlpha(1, 2f, false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timer);
        fontAnim.SetBool("animateFont", true);
        FadeIn();
    }
}
