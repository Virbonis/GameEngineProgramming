using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    public void Update()
    {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers) {
            if (!renderer.CompareTag("Blood") && !renderer.CompareTag("ClueTrap"))
            {
                renderer.sortingOrder = (int)(renderer.transform.position.y * -100);
            }
        }
    }
}
