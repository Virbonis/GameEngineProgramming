using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public Image Blackscreen;

    void Start()
    {
        Blackscreen.canvasRenderer.SetAlpha(1.0f);
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn() {
        Blackscreen.CrossFadeAlpha(0f, 1.5f, false);
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
