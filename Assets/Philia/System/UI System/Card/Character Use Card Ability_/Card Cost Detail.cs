using TMPro;
using UnityEngine;

public class CardCostDetail : MonoBehaviour
{
    public TextMeshProUGUI costText;

    public int origonCost = 0;

    public int currentCost = 0;

    [Header("Transition Effect")]
    public Color defualtCostColorEffect;

    public Color upCostColorEffect;

    public Color downCosColorEffect;

    public void SetCost(int cost)
    {
        origonCost = cost;

        this.currentCost = cost;

        CostInformationUpdateText();
    }

    public void ApplyCost(int cost)
    {
        this.currentCost += cost;

        SetCostEffect();
    }

    public void LowerCost(int cost)
    {
        this.currentCost -= cost;

        if(currentCost < 0)
        {
            currentCost = 0;
        }

        SetCostEffect();
    }

    #region

    public void SetCostEffect()
    {
        CostInformationUpdateText();

        if (currentCost == origonCost)
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
        if (currentCost > origonCost) { 
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

    #endregion

    private void CostInformationUpdateText()
    {
        costText.text = currentCost.ToString();
    }
}
