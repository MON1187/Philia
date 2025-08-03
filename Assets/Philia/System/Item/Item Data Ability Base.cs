using UnityEngine;

public enum itemType
{
    offensive,  //������
    support,    //������
    defensive   //�����
}

public enum itemRating
{
    low,       //3��
    middle,    //2��
    advanced   //1��
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
