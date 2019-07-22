using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInTrap : MonoBehaviour
{
    public Image target;
    public Image BackButton;
    private Teleport teleport;

    void Start()
    {
        target.canvasRenderer.SetAlpha(0.0f);
        BackButton.canvasRenderer.SetAlpha(0.0f);
        teleport = GameObject.FindWithTag("Teleport").GetComponent<Teleport>();
        FadeIn();
    }

    void FadeIn() {
        SoundManager.PlaySound("Note Pickup");
        teleport.killerTeleportOutside();
        BackButton.CrossFadeAlpha(1f, 0.15f, false);
        target.CrossFadeAlpha(1f, 0.15f, false);
    }

    void FadeOut() {
        target.CrossFadeAlpha(0f, 0.15f, false);
        BackButton.CrossFadeAlpha(0f, 0.15f, false);
    }
}
