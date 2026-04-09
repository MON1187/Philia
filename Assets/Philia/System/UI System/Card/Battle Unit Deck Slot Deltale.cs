using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BattleUnitDeckSlotDeltale : MonoBehaviour
{
    [SerializeField] private Transform createCardTransform;

    public List<AsyncOperationHandle<GameObject>> slots = new List<AsyncOperationHandle<GameObject>>();

    public async void SetSlot(int slotIndex = 0)
    {
        print("Start Create Slot");

        //default Value
        slotIndex += 1;

        print(slotIndex);

        for (int i = 0; i < slotIndex; i++)
        {
#if UNITY_EDITOR
            print("Cretea Slot Number : " + i);
#endif
            var handle = await GameDataManage.Inst.CreateCardSlot(createCardTransform);
            slots.Add(handle);
        }
    }

    public void OnEndTurn()
    {
        foreach(var item in slots)
        {
            GameDataManage.Inst.ReleaseInstanceResource<GameObject>(item);     
        }

        slots.Clear();
    }
}
