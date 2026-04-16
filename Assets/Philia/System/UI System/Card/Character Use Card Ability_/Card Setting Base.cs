using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardSettingBase : MonoBehaviour
{
    [Header("[ Data ]")]
    public CardData data;
    
    public CardTypeDetail cardType;

    public CardAbilityBase cardAbility;

    [Header("[ Model ]")]
    public BattleUnitModel owner;

    public BattleUnitModel target;

    [Header("[ Value ]")]
    public int cost;

    public int value;

    [Header("[ Resource ]")]
    public Image cardImage;

    public TextMeshProUGUI nameText;

    public CardTypeInformationDetail cardTypeDetail;

    public CardValueDetail cardValueDetail;

    public CardCostDetail cardCostDetail;

    public void CardSetting()
    {
        cardImage.sprite = data.cardImage;

        nameText.text = data.cardName.ToString();

        cardType = data.cardType;

        cardCostDetail.SetCost(data.cardCost);
    }

    public void UpdateCardBaseData()
    {
        cost = cardCostDetail.currentCost;
    }
}