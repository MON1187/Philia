using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardSettingBase : MonoBehaviour
{
    [Header("")]
    CardTypeDetail cardType;

    CardAbilityBase cardAbility;

    [Header("[ Model ]")]
    public BattleUnitModel owner;

    public BattleUnitModel target;

    [Header("[ Value ]")]
    public int cost;

    public int value;

    [Header("[ Resource ]")]
    public Image cardImage;

    public Image cardTypeIcon;

    public CardValueDetail cardValueDetail;

    public CardCostDetail cradCostDetail;


}