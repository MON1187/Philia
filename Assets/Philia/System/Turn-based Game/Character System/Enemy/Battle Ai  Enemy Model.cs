using System.Collections.Generic;
using UnityEngine;

public class BattleAiEnemyModel : MonoBehaviour
{
    BattleUnitModel owner;

    public List<CardSlot> cardSlot = new List<CardSlot>();

    public void AISetting(BattleUnitModel owner)
    {
        this.owner = owner;
    }

    public void PlayAIFunctionModel()
    {
        SetCardSlot();
    }


    public void SetCardSlot()
    {
        print("Set");
        cardSlot = owner.slotDeltale.cardDeck.slots;

        if(cardSlot.Count <= 0)
        {
            Invoke("SetCardSlot", 1);
        }
    }

    public void CardRegistration()
    {
        for (int i = 0; i < cardSlot.Count; i++)
        {
            cardSlot[i].CardDataRegistere(CardUsageClassification());
        }
    }

    /// <summary>
    /// Returns randomly based on the priority of the card data.
    /// </summary>
    public CardData CardUsageClassification()
    {
        CardData[] cardDataArray = new CardData[3];

        CardData cardData = new CardData();

        for(int i = 0; i < cardDataArray.Length; i++)
        {
            cardData = SwapCardData(cardData, cardDataArray[i]);
        }

        return cardData;
    }

    private CardData SwapCardData(CardData curCard, CardData swapCard)
    {
        CardData cardData = new CardData();

        if (curCard != null)
        {
            if (curCard.priority >= swapCard.priority)
            {
                cardData = curCard;
            }
            else{
                cardData = swapCard;
            }

        }

        return cardData;
    }
}
