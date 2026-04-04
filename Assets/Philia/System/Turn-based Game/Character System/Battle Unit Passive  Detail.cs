using System.Collections.Generic;
using UnityEngine;

public class BattleUnitPassiveDetail : MonoBehaviour
{
    public List<PassiveAbilityBase> passiveList = new List<PassiveAbilityBase>();


    public void OnBattleStart()
    {
        try
        {
            foreach (PassiveAbilityBase ab in passiveList)
            {
                ab.OnBattleStart();
            }
        }
        catch { }
    }

    public void OnTurnStart()
    {
        try
        {
            foreach (PassiveAbilityBase ab in passiveList)
            {
                ab.OnTurnStart();
            }
        }
        catch { }
    }

    public void OnTurnEnd()
    {
        try
        {
            foreach (PassiveAbilityBase ab in passiveList)
            {
                ab.OnTurnEnd();
            }
        }
        catch { }
    }

    public void OnDrawCard()
    {
        try
        {
            foreach (PassiveAbilityBase ab in passiveList)
            {
                ab.OnDrawCard();
            }
        }
        catch { }
    }
}
