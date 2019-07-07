using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTutorial : MonoBehaviour
{
    public Image fadeTargetMovement;
    public Image fadeTargetInteract;
    public Image fadeuseItem;
    public Image fadeinteractDoor;
    public Image fadeinDropitem;
    public Image BackButton;
    public Text lockedDoor;
    public Text BlockTheKiller;
    public Text GetAway;
    public static int counter = 0;
    public static int useItem = 0;
    public static int KillerTutorialCounter = 0;

    void Start()
    {
        fadeTargetMovement.canvasRenderer.SetAlpha(0.0f);
        fadeTargetInteract.canvasRenderer.SetAlpha(0.0f);
        fadeuseItem.canvasRenderer.SetAlpha(0.0f);
        fadeinteractDoor.canvasRenderer.SetAlpha(0.0f);
        fadeinDropitem.canvasRenderer.SetAlpha(0.0f);
        lockedDoor.canvasRenderer.SetAlpha(0.0f);
        BlockTheKiller.canvasRenderer.SetAlpha(0.0f);
        GetAway.canvasRenderer.SetAlpha(0.0f);
        BackButton.canvasRenderer.SetAlpha(0.0f);
        if (counter == 0)
        {
            FadeInMove();
        }
    }

    public void FadeInMove() {
        StartCoroutine(WaitBlackScreen());
        counter++;
    }

    public void KillerTutorialChase() {
        if (KillerTutorialCounter == 0) {
            StartCoroutine(KillerTutorial());
            KillerTutorialCounter++;
        }
    }

    public void UseItem() {
        if (useItem == 0)
        {
            StartCoroutine(useItemTut());
            useItem++;
        }
    }

    public void LockedDoor() {
        lockedDoor.canvasRenderer.SetAlpha(0.0f);
        fadeTargetMovement.CrossFadeAlpha(0f, 0.1f, false);
        fadeTargetInteract.CrossFadeAlpha(0f, 0.1f, false);
        fadeinteractDoor.CrossFadeAlpha(0f, 0.1f, false);
        StartCoroutine(LockedDoorWait());
    }

    public void FadeInBack()
    {
        StartCoroutine(BackWait());
    }

    public void FadeOutBack()
    {
        BackButton.CrossFadeAlpha(0f, 0.15f, false);
    }

    IEnumerator WaitBlackScreen()
    {
        yield return new WaitForSeconds(2f);
        fadeTargetMovement.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        fadeTargetMovement.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(2f);
        fadeTargetInteract.CrossFadeAlpha(1f, 1f, false);
        fadeinteractDoor.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        fadeTargetInteract.CrossFadeAlpha(0f, 1f, false);
        fadeinteractDoor.CrossFadeAlpha(0f, 1f, false);
    }

    IEnumerator useItemTut()
    {
        fadeuseItem.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(6f);
        fadeuseItem.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        fadeinDropitem.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        fadeinDropitem.CrossFadeAlpha(0f, 1f, false);
    }

    IEnumerator LockedDoorWait()
    {
        lockedDoor.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(3f);
        lockedDoor.CrossFadeAlpha(0f, 1f, false);
    }

    IEnumerator KillerTutorial()
    {
        yield return new WaitForSeconds(2f);
        BlockTheKiller.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        BlockTheKiller.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        GetAway.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        GetAway.CrossFadeAlpha(0f, 1f, false);
    }

    IEnumerator BackWait()
    {
        yield return new WaitForSeconds(0.0f);
        BackButton.CrossFadeAlpha(1f, 0.15f, false);
    }
}
