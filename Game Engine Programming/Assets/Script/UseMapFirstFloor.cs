using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMapFirstFloor : MonoBehaviour
{
    public GameObject firstFloor;
    public GameObject secondFloor;

    public void OpenFirstFloor() {
        firstFloor.SetActive(true);
    }

    public void OpenSecondFloor()
    {
        secondFloor.SetActive(true);
    }
}
