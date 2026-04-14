using TMPro;
using UnityEngine;

public class CardCostDetail : MonoBehaviour
{
    public TextMeshProUGUI costText;

    public int origonCost;

    public int cost;

    [Header("Transition Effect")]
    public Color defualtCostColorEffect;

    public Color upCostColorEffect;

    public Color downCosColorEffect;

    public void SetCost(int cost)
    {
        origonCost = cost;
    }

    public void ApplyCost(int cost)
    {
        this.cost += cost;
    }

    public void LowerCost(int cost)
    {
        this.cost += cost;

    }

    public void SetCostEffect()
    {
        if(cost == origonCost)
        {
            costText.color = defualtCostColorEffect;

            return;
        }
        else
        {
            SetCardCostInformation();
        }
    }

    private void SetCardCostInformation()
    {
        if (cost > origonCost) { 
            ApplyCostEffect();
        }
        else
        {
            LowerCostEffect();
        }
    }

    private void ApplyCostEffect()
    {
        costText.color = upCostColorEffect;
    }

    private void LowerCostEffect()
    {
        costText.color = downCosColorEffect;
    }
}
