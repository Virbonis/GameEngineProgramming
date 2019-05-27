using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    private Animator BloodAnim;
    private float timer = 1.5f;

    void Start()
    {
        BloodAnim = GetComponent<Animator>();
    }

    void Update()
    {
        BloodSplattering();
    }

    public void BloodSplattering() {
        if (KillerHit.hit == true)
        {
            BloodAnim.SetBool("Splatter", true);
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else {
                KillerHit.hit = false;
            }
        }
        else {
            BloodAnim.SetBool("Splatter", false);
        }
    }
}
