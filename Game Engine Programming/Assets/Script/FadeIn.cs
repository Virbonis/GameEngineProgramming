using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fadeInTarget;
    public Text fadeTextTarget;
    private FadeTutorial tutorial;

    void Start()
    {
        fadeInTarget.canvasRenderer.SetAlpha(0.0f);
        fadeTextTarget.canvasRenderer.SetAlpha(0.0f);
        tutorial = GameObject.FindWithTag("Tutorial").GetComponent<FadeTutorial>();
        Fadein();
    }

    public void Fadein() {
        fadeInTarget.CrossFadeAlpha(1f, 0.15f, false);
        tutorial.FadeInBack();
        SoundManager.PlaySound("Note Pickup");
    }

    public void FadeOut()
    {
        fadeTextTarget.CrossFadeAlpha(1f, 1f, false);
        tutorial.FadeOutBack();
        DestroyObject();
        StartCoroutine(wait());
    }

    public void DestroyObject() {
        StartCoroutine(waitDestroy());
    }

    IEnumerator wait() {
        SoundManager.PlaySound("Gain Knowledge");
        tutorial.fadeTargetMovement.CrossFadeAlpha(0f, 0.1f, false);
        tutorial.fadeTargetInteract.CrossFadeAlpha(0f, 0.1f, false);
        tutorial.fadeinteractDoor.CrossFadeAlpha(0f, 0.1f, false);
        tutorial.Syringe.CrossFadeAlpha(0f, 0.1f, false);
        tutorial.fewSeconds.CrossFadeAlpha(0f, 0.1f, false);
        tutorial.fadeuseItem.CrossFadeAlpha(0f, 0.1f, false);
        tutorial.lockedDoor.CrossFadeAlpha(0f, 0.1f, false);
        fadeInTarget.CrossFadeAlpha(0f, 0.15f, false);
        yield return new WaitForSeconds(6f);
        fadeTextTarget.CrossFadeAlpha(0f, 1f, false);
    }

    IEnumerator waitDestroy() {
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
