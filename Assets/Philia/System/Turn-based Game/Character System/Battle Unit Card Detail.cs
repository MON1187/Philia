using System.Collections.Generic;
using UnityEngine;

public class BattleUnitCardDetail : MonoBehaviour
{
    public  List<CardData> cardList;

    private CardData curUseCard;

    private BattleUnitModel owner;

    public void OnGetUnitModel(BattleUnitModel model)
    {
        owner = model;
    }

    public void CurrentUseCard(CardData useCard)
    {
        curUseCard = useCard;
    }

    public CardData CurrentUseCard()
    {
        return curUseCard;
    }


}
