using UnityEngine;

public class PassiveAbilityBase : MonoBehaviour
{
    protected BattleUnitData owner;

    public BattleUnitData Owner => owner;

    public virtual void OnBattleStart() { }

    public virtual void OnTurnStart() { }

    public virtual void OnTurnEnd() { }

    public virtual void OnDrawCard() { }

    public virtual void OnWinParrying() { }

    public virtual void OnLoseParrying() { }

    public virtual void OnUseCard() { }

    public virtual int UseSkillSlotAdder()
    {
        return 0;
    }

    public virtual int MaxPlayPointAdder()
    {
        return 0;
    }

    public virtual int RecoverPlayPoint()
    {
        return 0;
    }
}
