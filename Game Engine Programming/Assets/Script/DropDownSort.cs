using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownSort : MonoBehaviour
{
    public string SortingLayerName = "Player";

    void Awake()
    {
        Canvas canvas = GetComponent<Canvas>();
        if (canvas != null)
            canvas.sortingLayerName = SortingLayerName;
    }
}
