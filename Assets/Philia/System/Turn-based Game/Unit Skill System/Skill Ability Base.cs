using System.Collections;
using UnityEditor.Playables;
using UnityEngine;

public class CardAbilityBase : MonoBehaviour
{
    protected Sprite icon;

    protected BattleUnitModel owner;

    BattleUnitModel _target;

    int _cost;

    int _oringCost;

    bool _isReadySkillMotion = false;

    public int dmgRate;

    public string explanation;

    protected float productionTime;

    [SerializeField] private CardType cardType;

    public CardType OnGetType() { return cardType; }

    public void OnUseSkill()
    {
        if(owner.currentActionPoint < _cost)
        {
            return;
        }

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

    public int Cost()
    {
        return _cost;
    }

    public void AddCost(int value = 0)
    {
        _cost += value;
    }
}
