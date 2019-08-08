using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialTimer : MonoBehaviour
{
    private float timer;
    public float timerRadial;
    Image Radial;

    void Start()
    {
        Radial = this.GetComponent<Image>();
        Radial.fillAmount = 0;
        timerRadial = timer;
    }

    void Update()
    {
        if (timerRadial > 0) {
            timerRadial -= Time.deltaTime;
            Radial.fillAmount = timerRadial / 8f;
        }
    }
}
