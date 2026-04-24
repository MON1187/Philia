using System.Collections.Generic;
using UnityEngine;

public class CardSlotManger : MonoBehaviour
{
    public List<CardSlot> slots;

    public List<CardData> cardDeckHand;

    public List<CardData> discardedCard;

    public List<CardData> cardConfigurationList;

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
