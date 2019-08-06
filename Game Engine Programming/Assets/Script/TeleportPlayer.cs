using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public GameObject playerObject;
    public GameObject ScaryImage;
    public DeactivateCharlie Charlie;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void Start()
    {
        Charlie = GameObject.Find("Charlie Teleport").GetComponent<DeactivateCharlie>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.position = target.transform.position;
            Charlie.TeleportPlayer();
            gameObject.SetActive(false);
        }
    }
}
