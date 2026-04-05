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

    public void OnTurnFirstStart()
    {
        try
        {
            foreach(PassiveAbilityBase ab in passiveList)
            {
                ab.OnTurnFirstStart();
            }
        }
        catch {}
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

    public int OnActionPointAdder()
    {
        int value = 0;

        foreach(PassiveAbilityBase ab in passiveList)
        {
            value += ab.MaxPlayPointAdder();
        }

        return value;
    }

    public int OnRecoverPoint()
    {
        int value = 0;

        foreach (PassiveAbilityBase ab in passiveList)
        {
            value += ab.RecoverPlayPoint();
        }

        return value;
    }
}
