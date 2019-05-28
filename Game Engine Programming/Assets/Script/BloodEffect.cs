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
    }

    void Update()
    {
        BloodSplattering();
    }

    public void BloodSplattering() {
        if (KillerHit.hit == true)
        {
            BloodAnim.SetBool("Splatter", true);
            Debug.Log("blood is comin' out");
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
