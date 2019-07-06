using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    private Animator BloodAnim;
    private float timer = 1.5f;
    public static bool delay;

    void Start()
    {
        BloodAnim = GetComponent<Animator>();
        KillerHit.blood = false;
    }

    void Update()
    {
        BloodSplattering();
    }

    public void BloodSplattering() {
        if (KillerHit.blood == true)
        {
            BloodAnim.SetBool("Splatter", true);
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else {
                KillerHit.blood = false;
            }
        }
        else {
            BloodAnim.SetBool("Splatter", false);
        }
    }
}
