using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownAdrenaline : MonoBehaviour
{
    public float timer;
    private Player player;
    private bool send;
    public bool AdrenalineEffect;
    public GameObject Radial;
    public GameObject SyringeImage;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (timer > 0)
        {
            send = true;
            AdrenalineEffect = true;
            timer -= Time.deltaTime;
            Radial.SetActive(true);
            SyringeImage.SetActive(true);
        }
        else if(timer < 0 && send == true)
        {
            gameObject.SendMessage("speedReturn");
            AdrenalineEffect = false;
            send = false;
            Radial.SetActive(false);
            SyringeImage.SetActive(false);
        }
    }
}
