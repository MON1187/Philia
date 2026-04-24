using TMPro;
using UnityEngine;

public class CardValueDetail : MonoBehaviour
{
    public TextMeshProUGUI valueText;

    public BattleUnitModel owenr;

    public CardAbilityBase cardAbility;

    public int value;

    public void SetOwner(BattleUnitModel _owern)
    {
        owenr = _owern;
    }

    public void UpdateValue()
    {
        if (owenr != null && cardAbility != null)
        {
            int power = owenr.GetUnitData().st_Strong;

            //int skillAddPower = cardAbility.

            value = power;

            valueText.text = value.ToString();
        }
        else
        {
            valueText.text = "Null Value";
        }
    }
}
