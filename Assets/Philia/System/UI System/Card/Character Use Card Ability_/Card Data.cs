using UnityEngine;

[CreateAssetMenu(fileName = "New Card Data", menuName = "Philia Assets/Card Assets/Create New Card Data")]
public class CardData : ScriptableObject
{
    [Header("Value")]
    public string cardName = "";

    public int cardCost = 0;

    public CardTypeDetail cardType = default(CardTypeDetail);

    public bool disposable;

    [Header("Resource")]
    public Sprite cardImage;

}
