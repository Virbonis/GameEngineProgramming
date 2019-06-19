using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject keyGUI;
    public GameObject player;

    void Update()
    {
        if (InteractionObject.GUI_pause == true)
        {
            if (Time.timeScale == 1)
            {
                keyGUI.SetActive(true);
                player.SetActive(false);
                Time.timeScale = 0;
            }
            else
            {
                if (Input.GetKeyDown("e"))
                {
                    InteractionObject.GUI_pause = false;
                    keyGUI.SetActive(false);
                    player.SetActive(true);
                }
            }
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
