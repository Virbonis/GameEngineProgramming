using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingImage : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
