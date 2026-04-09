using System.Collections.Generic;
using UnityEngine;

public class BattleUnitCardDetail : MonoBehaviour
{
    public  List<CardAbilityBase> cardList;

    private CardAbilityBase curUseCard;

    private BattleUnitModel owner;

    public void OnGetUnitModel(BattleUnitModel model)
    {
        owner = model;
    }

    public void CurrentUseCard(CardAbilityBase useCard)
    {
        curUseCard = useCard;
    }

    public CardAbilityBase CurrentUseCard()
    {
        return curUseCard;
    }


}
