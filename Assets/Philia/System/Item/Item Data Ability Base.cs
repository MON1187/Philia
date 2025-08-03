using UnityEngine;

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

    public int _value;

    BattleUnitModel owner;

    public Sprite _sprite;

    public virtual void ItemPassiveActivate()
    {
        ItemPassiveAbilityBase();
    }

    public virtual void ItemPassiveAbilityBase() 
    { 
    
    }
}
