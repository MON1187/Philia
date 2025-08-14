using UnityEngine;
using UnityEngine.UI;

public enum itemType
{
    offensive,  //공격형
    support,    //지원형
    defensive   //방어형
}

public enum itemRating
{
    low,       //3급
    middle,    //2급
    advanced   //1급
}

public class ItemDataAbilityBase : MonoBehaviour
{
    public int _id;

    public string _name;

    public itemType _itemType;

    public itemRating _rating;

    public Sprite _itemIcon;

    public string _itemName;

    public string _itemDescription;

    public bool isPassive;

    public int _pricec;

    protected BattleUnitModel owner;

    public BattleUnitModel _battleUnit;

    public void SetOwnerBattleUnitModel(BattleUnitModel _owner)
    {
        owner = _owner;
    }

    public void ItemPassiveActivate()
    {
        ItemPassiveAbilityBase();
    }

    protected virtual void ItemPassiveAbilityBase() 
    { 
    
    }

    public void OnItemBuffer()
    {
        ItemBufferAblilty();
    }

    protected virtual void ItemBufferAblilty()
    {

    }

    public Sprite GetItemAbilityIcon()
    {
        return _itemIcon;
    }
}
