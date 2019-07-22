using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRoom : MonoBehaviour
{
    private AudioSource saveTheme;
    public GameObject saveRoomTheme;
    private int counter = 1;
    private bool play = false;

    void Start()
    {
        saveTheme = GameObject.FindWithTag("Save Room").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (play == true)
        {
            saveTheme.volume += Time.deltaTime * 0.2f;
        }
        else {
            saveTheme.volume -= Time.deltaTime * 0.3f;
        }

        if (saveTheme.volume > 0)
        {
            saveRoomTheme.SetActive(true);
        }
        else {
            saveRoomTheme.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            play = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            play = false;
        }
    }
}
