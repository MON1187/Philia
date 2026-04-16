using System.Collections;
using UnityEditor.Playables;
using UnityEngine;

public class CardAbilityBase : MonoBehaviour
{
    //protected Sprite icon;

    protected BattleUnitModel owner;

    BattleUnitModel _target;

    bool _isReadySkillMotion = false;

    public int dmgRate;

    public string explanation;

    protected float productionTime;

    [SerializeField] private CardTypeDetail cardType;

    public CardTypeDetail OnGetType() { return cardType; }

    public void OnUseSkill()
    {
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

    public void UseSkillReady()
    {
        owner.SetUseSkillData(this, productionTime);
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
        owner.InflictDamage(owner.GetForce(), target);
    }

    protected virtual void UseSkillMotionReady()
    {
        StartCoroutine(UseSkillPlayMotion());
    }

    protected virtual IEnumerator UseSkillPlayMotion()
    {
        yield return null;
    }

    public virtual void SetPassiveAbilitySkill()
    {

    }
}
