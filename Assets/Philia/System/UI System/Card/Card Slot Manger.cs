using System.Collections.Generic;
using UnityEngine;

public class CardSlotManger : MonoBehaviour
{
    public List<CardSlot> slots;

    public void SetCardSlots()
    {
        Debug.Log("Set Card Slots");
        try
        {
            slots.Clear();

            slots.AddRange(GetComponentsInChildren<CardSlot>());
        }
        catch { }
    }
}
