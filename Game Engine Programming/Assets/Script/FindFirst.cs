using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindFirst : MonoBehaviour
{
    public Text Target;
    void Start()
    {
        Target.canvasRenderer.SetAlpha(0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Display();
        }
    }

    void Display() {
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        Target.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        Target.CrossFadeAlpha(0f, 1f, false);
    }
}
