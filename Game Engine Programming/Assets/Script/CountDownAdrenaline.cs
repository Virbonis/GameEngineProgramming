using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownAdrenaline : MonoBehaviour
{
    public float timer;
    private Player player;
    private bool send;
    public bool AdrenalineEffect;

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
        }
        else if(timer < 0 && send == true)
        {
            gameObject.SendMessage("speedReturn");
            AdrenalineEffect = false;
            send = false;
        }
        Debug.Log(AdrenalineEffect);
    }
}
