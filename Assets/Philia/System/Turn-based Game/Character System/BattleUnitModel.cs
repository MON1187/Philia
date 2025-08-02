using System;
using UnityEngine;

public enum faction
{
    Player,
    Enemy
}

public class BattleUnitModel : MonoBehaviour
{

    [SerializeField] private faction _faction;

    [SerializeField] private BattleUnitData _unitData;

    public int currentActionPoint;

    public int hp;

    public int breakLife;

    public SkillAbilityBase _basicSkill;

    public SkillAbilityBase _secondarySkill;

    public SkillAbilityBase _ultimateSkill;

    public faction GetFaction() { return _faction; }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        if (hp < 0)
        {
            TurnBasedManager.Instats.RemoveBattleUnitModel(this);

            //죽었을 때 연출 실행
            {

            }

            return;
        }
    }

    public virtual void StartRound()
    {
        currentActionPoint += 1;
    }

    public void RecoverHealth(int value)
    {
        hp += value;

        if (breakLife > _unitData.st_MaxHealth)
        {
            breakLife = _unitData.st_MaxHealth;
        }
    }

    public void RecoverBreak(int value)
    {
        breakLife += value;

        if(breakLife > _unitData.st_MaxBreakLife)
        {
            breakLife = _unitData.st_MaxBreakLife;
        }
    }
}


[Serializable]
public class BattleUnitData
{
    public int st_MaxHealth;
    public int st_MinHealth = 0;

    public int st_MaxBreakLife;
    public int st_MinBreakLife = 0;

    public struct ActionPoint
    {
        public int st_MaxActionPoint;
        public int st_StartActionPoint;
    }

    ActionPoint actionPoint;
}