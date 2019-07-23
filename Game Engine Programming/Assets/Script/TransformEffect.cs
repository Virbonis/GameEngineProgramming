using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEffect : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        transform.position = target.position;
    }

}
