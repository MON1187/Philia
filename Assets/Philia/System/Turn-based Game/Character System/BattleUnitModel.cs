using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum faction
{
    Player,
    Enemy
}

public class BattleUnitModel : MonoBehaviour
{
    [SerializeField] private faction _faction;

    [SerializeField] private BattleUnitData _unitData;

    public int maxActionPoint;

    public int currentActionPoint = 0;

    public int hp;

    public int breakLife;

    private UseSkillData useSkillData;

    public int _velocity;

    private BounsState _bounsState = new BounsState();

    private BattleUnitPassiveDetail passiveDetail;


    public UseSkillData GetUseSkillData()
    {
        return useSkillData;
    }

    public void TakeDamage(float dmg)
    {
        //추가 적인 연출 용 공간 ( 예시 : 회피, 피해 절감 )
        {

        }

        //Take damage heatlh
        int takeDmg = (int)dmg;

        DamagePopup.Create(transform.position, takeDmg, false);

        hp -= takeDmg;

        //Take damgae breaklife
        //breakLife -= (int)(dmg * (_bounsState.breakRate * 0.01f) + _bounsState.breakDmg);

        if (hp < 0)
        {
            TurnBasedManager.Instats.RemoveBattleUnitModel(this);

            //죽었을 때 연출 실행
            {
                StartCoroutine(DeathDirectingMotion());
            }

            return;
        }
    }

    public void InflictDamage(float force, BattleUnitModel target)
    {
        float dmg = (force + (force * (_bounsState.dmgRate * 0.01f) + _bounsState.dmg));

        target.TakeDamage(dmg);
    }

    public void OnBattleStart()
    {
        hp = _unitData.st_MaxHealth;
        breakLife = _unitData.st_MaxBreakLife;
        maxActionPoint = _unitData.st_MaxActionPoint + passiveDetail.OnActionPointAdder();
        currentActionPoint += _unitData.st_StartActionPoint;
    }

    public void OnTurnFirstStart()
    {
        passiveDetail.OnTurnFirstStart();
    }

    public void OnTurnStart()
    {
        maxActionPoint = _unitData.st_MaxActionPoint + passiveDetail.OnActionPointAdder();

        currentActionPoint += _unitData.st_StartActionPoint + passiveDetail.OnRecoverPoint();

        if (currentActionPoint > _unitData.st_MaxActionPoint)
        {
            currentActionPoint = _unitData.st_MaxActionPoint;
        }

        ApplyStateBouns(_bounsState);

        passiveDetail.OnTurnStart();
    }

    public void OnTurnEnd()
    {
        ResetStateBouns();

        passiveDetail.OnTurnEnd();
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

    public void RecoverPlayPoint(int value)
    {
        currentActionPoint += value;
    }

    public void SetUseSkillData(SkillAbilityBase useSkill, float time)
    {
        useSkillData.useSkill = useSkill;
        useSkillData.playSkillDirectingTime = time;
    }

    public IEnumerator DeathDirectingMotion()
    {
        yield return null;

        Destroy(this);
    }

    public void ApplyStateBouns(BounsState state)
    {
        _bounsState.dmg += state.dmg;
        _bounsState.breakDmg += state.breakDmg;
        _bounsState.dmgRate += state.dmgRate;
        _bounsState.breakRate += state.breakRate;
        _bounsState.str += state.str;
        _bounsState.point += state.point;
    }

    private void ResetStateBouns()
    {
        _bounsState.dmg = 0;
        _bounsState.breakDmg = 0;
        _bounsState.dmgRate = 0;
        _bounsState.breakRate = 0;
        _bounsState.str = 0;
        _bounsState.point = 0;
    }

    public int GetSpeed()
    {
        return _unitData.st_Speed + _velocity;
    }

    public int GetForce()
    {
        return _unitData.st_Strong + _bounsState.str;
    }

    public faction GetFaction() { return _faction; }

    public BattleUnitData GetUnitData() { return _unitData; }
}


[Serializable]
public class BattleUnitData
{
    public int id = 10000;

    public string name;

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
    public float playSkillDirectingTime;
}