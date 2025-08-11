using System;
using System.Drawing;
using System.Linq;
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

    public SkillAbilityBase _basicSkill;        //Normal Attack Base Skill

    public SkillAbilityBase _secondarySkill;    //Buf Skill

    public SkillAbilityBase _ultimateSkill;     //Ultimate Skill

    public SkillAbilityBase _passiveSkill;      //Passive Skill

    private UseSkillData useSkillData;

    public int _velocity;

    public bool isReady = false;

    private BounsState _bounsState = new BounsState();

    public faction GetFaction() { return _faction; }

    public int GetSpeed()
    {
        return _unitData.st_Speed + _velocity;
    }

    public void TakeDamage(int dmg)
    {
        //추가 적인 연출 용 공간 ( 예시 : 회피, 피해 절감 )
        {

        }
   
        //Take damage heatlh
        hp -= dmg + (int)(dmg * (_bounsState.dmgRate * 0.01f) + _bounsState.dmg);

        //Take damgae breaklife
        breakLife -= (int)(dmg * (_bounsState.breakRate * 0.01f) + _bounsState.breakDmg);

        if (hp < 0)
        {
            TurnBasedManager.Instats.RemoveBattleUnitModel(this);

            //죽었을 때 연출 실행
            {

            }

            return;
        }
    }

    public int GetForce()
    {
        return _unitData.st_Strong + _bounsState.str;
    }

    public void firstStartRound()
    {
        hp = _unitData.st_MaxHealth;
        breakLife = _unitData.st_MaxBreakLife;
        currentActionPoint = _unitData.st_StartActionPoint;


        //Set Skill Owner
        {
            if (_basicSkill != null)
                _basicSkill.SetOwnerBattleUnitModel(this);

            if (_secondarySkill != null)
                _secondarySkill.SetOwnerBattleUnitModel(this);

            if (_ultimateSkill != null)
                _ultimateSkill.SetOwnerBattleUnitModel(this);

            if(_passiveSkill != null)
                _passiveSkill.SetOwnerBattleUnitModel(this);
        }

        if (_passiveSkill != null)
            _passiveSkill.SetPassiveAbilitySkill(); 
    }

    public virtual void StartRound()
    {
        isReady = false;

        currentActionPoint += 1 + _bounsState.point;

        if (currentActionPoint > _unitData.st_MaxActionPoint)
        {
            currentActionPoint = _unitData.st_MaxActionPoint;
        }

        //Select Attack Target
        {
            BattleUnitModel[] target;

            if (_faction == faction.Player)
            {
                target = TurnBasedManager.Instats.enemyBattleUnitList.ToArray();
                SetTargeting(target,target.Length);
            }
            else if (_faction == faction.Enemy)
            {
                target = TurnBasedManager.Instats.playerBattleUnitList.ToArray();
                SetTargeting(target, target.Length);
            }
        }
    }

    private void SetTargeting(BattleUnitModel[] target, int size)
    {
        int randomIndex = UnityEngine.Random.Range(0, size);

        if (_basicSkill != null)
            _basicSkill.SetTargetBattleUnitModel(target[randomIndex]);

        if (_secondarySkill != null)
            _secondarySkill.SetTargetBattleUnitModel(target[randomIndex]);

        if (_ultimateSkill != null)
            _ultimateSkill.SetTargetBattleUnitModel(target[randomIndex]);
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

    public void SetUseSkillData(SkillAbilityBase useSkill, float time)
    {
        useSkillData.useSkill = useSkill;
        useSkillData.playSkillProductionTime = time;
    }

    public UseSkillData GetUseSkill()
    {
        return useSkillData;
    }


}


[Serializable]
public class BattleUnitData
{
    public int st_MaxHealth;
    public int st_MinHealth = 0;

    public int st_MaxBreakLife;
    public int st_MinBreakLife = 0;

    public int st_Speed;

    public int st_Strong;

    public int st_MaxActionPoint;
    public int st_StartActionPoint;
}

public class BounsState
{
    public int dmg;

    public int breakDmg;

    public int dmgRate;

    public int breakRate;

    public int str;

    public int point;

    public BounsState SetState()
    {
        return new BounsState()
        {
            dmg = dmg, 
            breakDmg = breakDmg,
            str = str,
            point = point,
            dmgRate = dmgRate,
            breakRate = breakRate
        };
    }
}

public struct UseSkillData
{
    public SkillAbilityBase useSkill;
    public float playSkillProductionTime;
}