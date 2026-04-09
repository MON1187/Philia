using System.Collections.Generic;
using UnityEngine;

public class BattleUnitDeckSlotDeltale : MonoBehaviour
{
    [SerializeField] private Transform createCardTransform;

    private List<CardSlot> slots = new List<CardSlot>();

    public void SetSlot(int slotIndex = 0)
    {
        int defaultSlot = 1;

        for (int i = 0; i < defaultSlot + slotIndex; i++)
        {
            slots.Add(GameDataManage.Inst.CreateCardSlolt(default, createCardTransform));
            //slots.Add(Instantiate(slotObj, transform.position, Quaternion.identity).GetComponent<CardSlot>());
        }
    }

    public void OnEndTurn()
    {
        foreach(var item in slots)
        {
            Destroy(item.gameObject);
        }

        slots.RemoveAt(slots.Count);

    }
}
