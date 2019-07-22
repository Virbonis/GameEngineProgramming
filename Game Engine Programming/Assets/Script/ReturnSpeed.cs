using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnSpeed : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void speedReturn()
    {
        player.speed = 5f;
    }
}
