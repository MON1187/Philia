using System.Collections.Generic;
using UnityEngine;

public class DeckBuildingFeatures : MonoBehaviour
{
    [SerializeField] private List<CardSettingBase> cardList = new List<CardSettingBase>();

    public void AddCardData(CardSettingBase cardData)
    {
        cardList.Add(cardData);
    }

    public void RemoveCard(CardSettingBase cardData)
    {
        cardList.Remove(cardData);
    }

    public CardSettingBase[] LoadCardDeckArray()
    {
        return cardList.ToArray();
    }
}