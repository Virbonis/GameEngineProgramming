using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nathan : MonoBehaviour
{
    public Text Target;
    void Start()
    {
        Target.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(3f);
        Target.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        Target.CrossFadeAlpha(0f, 1f, false);
    }
}
