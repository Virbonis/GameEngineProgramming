using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public static bool GUI_pause;

    public void DoInteraction()
    {
        gameObject.SetActive(false);
        SoundManager.PlaySound("Pickup Key");
        GUI_pause = true;
    }
}
