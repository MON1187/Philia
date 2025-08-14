using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;

public class StoreSystem : MonoBehaviour
{
    public int maxSellSlot = 3;

    public float lowProbability = 0.72f;            //3급 아이템 등장 확률 : 기본 0.72%(1%중)

    public float middleProbability = 0.025f;        //2급 아이템 등장 확률 : 기본 0.25%(1%중)

    public float advancedProbability = 0.03f;       //1급 아이템 등장 확률 : 기본 0.03%(1%중);

    public GameObject sellItemSlolt;

    public List<ItemDataAbilityBase> itemDataAbilityList;

    private ItemDataAbilityBase[] checkItemData;

    [SerializeField] private Transform spawnPos;

    private void Start()
    {
        ResetItemDisplaySlot();
    }

    public void ResetItemDisplaySlot()
    {
        //이전 상점에서 빠진 아이템 재 참조.
        ResetItemData();

        ResetItemSlot();
    }

    private void ResetItemSlot()
    {
        RandomSpawonItem();
    }

    private void RandomSpawonItem()
    {
        ItemSlot[] itemSlot = new ItemSlot[maxSellSlot];

        checkItemData = new ItemDataAbilityBase[maxSellSlot];

        for (int i = 0; i < maxSellSlot; i++)
        {
            GameObject slotObj = Instantiate(sellItemSlolt, spawnPos);

            checkItemData[i] = itemDataAbilityList[0];

            itemDataAbilityList.Remove(checkItemData[i]);

            itemSlot[i] = slotObj.GetComponent<ItemSlot>();

            itemSlot[i].SettingGetMask(checkItemData[i].GetItemAbilityIcon());
        }
    }

    private void ResetItemData()
    {
        if (checkItemData == null)
            return;

        foreach(ItemDataAbilityBase itemData in checkItemData)
        {
            itemDataAbilityList.Add(itemData);
        }
    }
}
