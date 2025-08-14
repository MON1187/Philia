using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //BattleUnitModel owner;

    public ItemDataAbilityBase itemData;

    private Button myBtn;

    [SerializeField] private GameObject sellIcon;

    [SerializeField] private Image mainIcom;

    private void Start()
    {
        if(sellIcon != null)
        sellIcon.SetActive(false);

        myBtn = GetComponent<Button>();

        myBtn.onClick.RemoveAllListeners();
        myBtn.onClick.AddListener(() => SellItem());
    }

    public void SellItem()
    {
        //A system that removes money equivalent to the price
        {
            // -= itemData._pricec;
        }

        //Write code to pass the item.
        {

        }

        //Prevent secondary clicks
        {
            if (sellIcon != null)
            sellIcon.SetActive(true);
            Destroy(myBtn);
        }
    }

    public void SettingGetMask(Sprite sprite)
    {
        mainIcom.sprite = sprite;
    }

    //public void GetUnitModelData(BattleUnitModel _owner)
    //{
    //    //owner = _owner;

    //    itemData.SetOwnerBattleUnitModel(_owner);
    //}

    //public void UseItem()
    //{
    //    if (itemData.isPassive)
    //    {
    //        itemData.ItemPassiveActivate();
    //    }
    //    else
    //    {
    //        itemData.OnItemBuffer();
    //    }
    //}
}