using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMedicine : MonoBehaviour
{
    private Slot slot;

    private void Start()
    {
        slot = GameObject.FindWithTag("Slot").GetComponent<Slot>();
    }

    public void useMedicine() {
        Health.health += 1;
        slot.DropItem();
        slot.DestroyTextItem();
    }
}
