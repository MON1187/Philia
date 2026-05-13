using System.Collections.Generic;
using UnityEngine;

public class ModelDeckManager : MonoBehaviour
{
    public DeckBuildingFeatures buildingFeatures;

    public List<CardSettingBase> deckCards = new List<CardSettingBase>();                   //Cards currently in the deck

    public List<CardSettingBase> handCards = new List<CardSettingBase>();                   //Cards currently in hand

    public List<CardSettingBase> abandonedCards = new List<CardSettingBase>();              //Current discarded cards

    #region Setting Deck

    public void OnGameStartSettingsDeck()
    {
        LoadCardDeck();
    }

    public void LoadCardDeck()
    {
        deckCards.AddRange(buildingFeatures.LoadCardDeckArray());

        ShufflDeck();
    }

    public void ShufflDeck()
    {
        for(int i = deckCards.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            var temp = deckCards[i];
            deckCards[i] = deckCards[randomIndex];
            deckCards[randomIndex] = temp;
        }
    }

    #endregion

    #region In Gameing Add Cards

    public void AddCardHand(CardSettingBase card)
    {

    }

    public void AddCardDeck(CardSettingBase card)
    {

    }

    #endregion
}
