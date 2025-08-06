using System.Collections;
using UnityEditor.Playables;
using UnityEngine;

public class SkillAbilityBase : MonoBehaviour
{
    public Sprite icon;

    BattleUnitModel owner;

    BattleUnitModel _target;

    int _cost;

    int _oringCost;

    bool _isReadySkillMotion = false;

    public bool _isPassiveSkill = false;

    public int _coolTime = 0;

    int _curTime = 0;

    public int dmgRate;

    public void OnUseSkill()
    {
        if (_isPassiveSkill)
        {
            UsePassiveSkill();
            return;
        }

        if(owner.currentActionPoint < _cost || _curTime < _coolTime)
        {
            _curTime += 1;
            return;
        }

        _curTime = _coolTime;

        owner.currentActionPoint  -= _cost;

        //사전 기술 사용 준비 연출
        {
            if (_isReadySkillMotion)
            {
                //연출 함수 호출
                UseSkillMotionReady();

                return;
            }
        }

        //타격 효과 연출
        {
            UseSkillEffectAbilityBase();
        }

        //피해 입히는 함수
        {
            UseSkillAbilityBase(_target);
        }
    }

    protected virtual void UseSkillEffectAbilityBase()
    {

    }

    public void SetOwnerBattleUnitModel(BattleUnitModel owner)
    {
        this.owner = owner;
    }

    public void SetTargetBattleUnitModel(BattleUnitModel target)
    {
        _target = target;
    }

    protected virtual void UseSkillAbilityBase(BattleUnitModel target)
    {
        target.TakeDamage(owner.GetForce());
    }

    protected virtual void UseSkillMotionReady()
    {
        StartCoroutine(UseSkillPlayMotion());
    }

    protected virtual IEnumerator UseSkillPlayMotion()
    {
        yield return null;
    }

    protected virtual void UsePassiveSkill()
    {

    }

    public int Cost()
    {
        return _cost;
    }

    public void AddCost(int value = 0)
    {
        _cost += value;
    }
}
