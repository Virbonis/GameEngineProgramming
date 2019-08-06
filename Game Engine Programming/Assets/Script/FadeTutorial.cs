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
    public Text fullInven;
    public Text fullHealth;
    public Text DropItem;
    public Text Syringe;
    public Image pointerImage;
    public Transform[] transforms;
    public GameObject GainKnowledge;
    public static int counter = 0;
    public static int useItem = 0;
    public static int KillerTutorialCounter = 0;
    public static int syringe = 0;
    public Transform pointer;
    public GameObject pointerActivate;
    private Inventory searchInventory;

    void Start()
    {
        searchInventory = GameObject.Find("Player").GetComponent<Inventory>();
        pointerImage.canvasRenderer.SetAlpha(0.0f);
        fadeTargetMovement.canvasRenderer.SetAlpha(0.0f);
        fadeTargetInteract.canvasRenderer.SetAlpha(0.0f);
        fullInven.canvasRenderer.SetAlpha(0.0f);
        fadeuseItem.canvasRenderer.SetAlpha(0.0f);
        fadeinteractDoor.canvasRenderer.SetAlpha(0.0f);
        fadeinDropitem.canvasRenderer.SetAlpha(0.0f);
        lockedDoor.canvasRenderer.SetAlpha(0.0f);
        BlockTheKiller.canvasRenderer.SetAlpha(0.0f);
        GetAway.canvasRenderer.SetAlpha(0.0f);
        fullHealth.canvasRenderer.SetAlpha(0.0f);
        BackButton.canvasRenderer.SetAlpha(0.0f);
        DropItem.canvasRenderer.SetAlpha(0.0f);
        Syringe.canvasRenderer.SetAlpha(0.0f);
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
            fadeTargetMovement.canvasRenderer.SetAlpha(0.0f);
            fadeTargetInteract.canvasRenderer.SetAlpha(0.0f);
            fullInven.canvasRenderer.SetAlpha(0.0f);
            fadeuseItem.canvasRenderer.SetAlpha(0.0f);
            fadeinteractDoor.canvasRenderer.SetAlpha(0.0f);
            fadeinDropitem.canvasRenderer.SetAlpha(0.0f);
            lockedDoor.canvasRenderer.SetAlpha(0.0f);
            fullHealth.canvasRenderer.SetAlpha(0.0f);
            BackButton.canvasRenderer.SetAlpha(0.0f);
            Syringe.canvasRenderer.SetAlpha(0.0f);
            DropItem.canvasRenderer.SetAlpha(0.0f);
            StartCoroutine(KillerTutorial());
            KillerTutorialCounter++;
        }
    }

    public void useSyringe() {
        if (syringe == 0)
        {
            syringe++;
            fadeTargetMovement.canvasRenderer.SetAlpha(0.0f);
            fadeTargetInteract.canvasRenderer.SetAlpha(0.0f);
            fullInven.canvasRenderer.SetAlpha(0.0f);
            fadeinteractDoor.canvasRenderer.SetAlpha(0.0f);
            lockedDoor.canvasRenderer.SetAlpha(0.0f);
            BlockTheKiller.canvasRenderer.SetAlpha(0.0f);
            GetAway.canvasRenderer.SetAlpha(0.0f);
            fullHealth.canvasRenderer.SetAlpha(0.0f);
            BackButton.canvasRenderer.SetAlpha(0.0f);
            DropItem.canvasRenderer.SetAlpha(0.0f);
            Syringe.canvasRenderer.SetAlpha(0.0f);
            StartCoroutine(useSyringeWait());
            UseItem();
        }
    }

    public void UseItem() {
        if (useItem == 0)
        {
            for (int x = 0; x < searchInventory.inventory.Length; x++)
            {
                if (searchInventory.inventory[x].CompareTag("Item") ||
                    searchInventory.inventory[x].CompareTag("Syringe"))
                {
                    pointer.transform.position = transforms[x].transform.position;
                    pointerActivate.SetActive(true);
                    StartCoroutine(useItemTut());
                    StartCoroutine(pointerWait());
                }
            }
        }
        useItem++;
    }

    public void pointerDestroy() {
        Destroy(pointerActivate);
    }

    public void LockedDoor() {
        fadeTargetMovement.canvasRenderer.SetAlpha(0.0f);
        fadeTargetInteract.canvasRenderer.SetAlpha(0.0f);
        fullInven.canvasRenderer.SetAlpha(0.0f);
        fadeuseItem.canvasRenderer.SetAlpha(0.0f);
        fadeinteractDoor.canvasRenderer.SetAlpha(0.0f);
        fadeinDropitem.canvasRenderer.SetAlpha(0.0f);
        lockedDoor.canvasRenderer.SetAlpha(0.0f);
        BlockTheKiller.canvasRenderer.SetAlpha(0.0f);
        GetAway.canvasRenderer.SetAlpha(0.0f);
        Syringe.canvasRenderer.SetAlpha(0.0f);
        fullHealth.canvasRenderer.SetAlpha(0.0f);
        BackButton.canvasRenderer.SetAlpha(0.0f);
        DropItem.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(LockedDoorWait());
    }

    public void CantDrop() {
        fadeTargetMovement.canvasRenderer.SetAlpha(0.0f);
        fadeTargetInteract.canvasRenderer.SetAlpha(0.0f);
        fullInven.canvasRenderer.SetAlpha(0.0f);
        fadeuseItem.canvasRenderer.SetAlpha(0.0f);
        fadeinteractDoor.canvasRenderer.SetAlpha(0.0f);
        fadeinDropitem.canvasRenderer.SetAlpha(0.0f);
        lockedDoor.canvasRenderer.SetAlpha(0.0f);
        BlockTheKiller.canvasRenderer.SetAlpha(0.0f);
        GetAway.canvasRenderer.SetAlpha(0.0f);
        fullHealth.canvasRenderer.SetAlpha(0.0f);
        BackButton.canvasRenderer.SetAlpha(0.0f);
        DropItem.canvasRenderer.SetAlpha(0.0f);
        Syringe.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(DropItemDisplay());
    }

    public void FadeInBack()
    {
        StartCoroutine(BackWait());
    }

    public void FadeOutBack()
    {
        BackButton.CrossFadeAlpha(0f, 0.15f, false);
    }

    public void fullInventory() {
        fadeTargetMovement.canvasRenderer.SetAlpha(0.0f);
        fadeTargetInteract.canvasRenderer.SetAlpha(0.0f);
        fullInven.canvasRenderer.SetAlpha(0.0f);
        fadeuseItem.canvasRenderer.SetAlpha(0.0f);
        fadeinteractDoor.canvasRenderer.SetAlpha(0.0f);
        fadeinDropitem.canvasRenderer.SetAlpha(0.0f);
        lockedDoor.canvasRenderer.SetAlpha(0.0f);
        BlockTheKiller.canvasRenderer.SetAlpha(0.0f);
        GetAway.canvasRenderer.SetAlpha(0.0f);
        fullHealth.canvasRenderer.SetAlpha(0.0f);
        BackButton.canvasRenderer.SetAlpha(0.0f);
        Syringe.canvasRenderer.SetAlpha(0.0f);
        DropItem.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(fullInventoryText());
    }

    public void fullHealthDisplay() {
        fadeTargetMovement.canvasRenderer.SetAlpha(0.0f);
        fadeTargetInteract.canvasRenderer.SetAlpha(0.0f);
        fullInven.canvasRenderer.SetAlpha(0.0f);
        fadeuseItem.canvasRenderer.SetAlpha(0.0f);
        fadeinteractDoor.canvasRenderer.SetAlpha(0.0f);
        fadeinDropitem.canvasRenderer.SetAlpha(0.0f);
        lockedDoor.canvasRenderer.SetAlpha(0.0f);
        BlockTheKiller.canvasRenderer.SetAlpha(0.0f);
        GetAway.canvasRenderer.SetAlpha(0.0f);
        fullHealth.canvasRenderer.SetAlpha(0.0f);
        BackButton.canvasRenderer.SetAlpha(0.0f);
        DropItem.canvasRenderer.SetAlpha(0.0f);
        Syringe.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(fullHealthText());
    }

    IEnumerator pointerWait() {
        pointerImage.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(8f);
        pointerImage.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        pointerDestroy();
    }

    IEnumerator useSyringeWait() {
        Syringe.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        Syringe.CrossFadeAlpha(0f, 1f, false);
    }

    IEnumerator DropItemDisplay() {
        DropItem.CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(4f);
        DropItem.CrossFadeAlpha(0f, 1f, false);
    }

    IEnumerator fullInventoryText() {
        fullInven.CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(4f);
        fullInven.CrossFadeAlpha(0f, 1f, false);
    }

    IEnumerator fullHealthText()
    {
        fullHealth.CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(5f);
        fullHealth.CrossFadeAlpha(0f, 1f, false);
    }

    IEnumerator WaitBlackScreen()
    {
        yield return new WaitForSeconds(2f);
        fadeTargetMovement.CrossFadeAlpha(1f, 1f, false);
        GainKnowledge.SetActive(false);
        yield return new WaitForSeconds(5f);
        fadeTargetMovement.CrossFadeAlpha(0f, 1f, false);
        GainKnowledge.SetActive(true);
        yield return new WaitForSeconds(2f);
        fadeTargetInteract.CrossFadeAlpha(1f, 1f, false);
        fadeinteractDoor.CrossFadeAlpha(1f, 1f, false);
        GainKnowledge.SetActive(false);
        yield return new WaitForSeconds(5f);
        GainKnowledge.SetActive(true);
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
        lockedDoor.canvasRenderer.SetAlpha(0.0f);
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
