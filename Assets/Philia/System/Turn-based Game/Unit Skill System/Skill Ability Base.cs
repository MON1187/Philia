using System.Collections;
using UnityEditor.Playables;
using UnityEngine;

//패시브 용
 
    // 적중 시

    // 피격 시

    // 전투 시작 시

    // 턴이 끝날 시

    // 턴 시작 시

    // 적 사망 시

    // 적 제거 시


//스킬

    // 버프

    // 적중 시



public class SkillAbilityBase : MonoBehaviour
{
    public Sprite icon;

    BattleUnitModel owner;

    BattleUnitModel _target;

    int _cost;

    int _oringCost;

    bool _isReadySkillMotion = false;

    public bool _isPassiveSkill = false;

    public int _coolTime;

    public int _curTime;

    public void OnUseSkill()
    {
        if (_isPassiveSkill)
        {
            UsePassiveSkill();
            return;
        }

        if(owner.currentActionPoint < _cost || _curTime < _coolTime)
        {
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
            UseSkillAbilityBase();
        }
    }

    protected virtual void UseSkillEffectAbilityBase()
    {

    }

    protected virtual void UseSkillAbilityBase()
    {

    }

    protected virtual void UseSkillMotionReady()
    {
        
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
