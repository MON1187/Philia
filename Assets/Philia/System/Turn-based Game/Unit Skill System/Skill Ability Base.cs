using System.Collections;
using UnityEditor.Playables;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

    #region Setting 

    public void SetOwnerBattleUnitModel(BattleUnitModel owner)
    {
        this.owner = owner;
    }

    public void SetTargetBattleUnitModel(BattleUnitModel target)
    {
        _target = target;
    }


    #endregion

    public void OnReadyUseCard()
    {
        OnUseCard();

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
            UseCardEffectAbilityBase();
        }

        //피해 입히는 함수
        {
            UseCardAbilityBase(_target);
        }
    }

    public void UseCardReady()
    {
        owner.SetUseSkillData(this, productionTime);
    }

    public virtual void OnUseCard()
    {

    }

    public virtual void UseCardEffectAbilityBase()
    {

    }

    protected virtual void UseCardAbilityBase(BattleUnitModel target)
    {
        Damaged(target);
    }

    protected virtual void Damaged(BattleUnitModel target)
    {
        owner.InflictDamage(owner.GetForce(), target);
    }

    public virtual void UseSkillMotionReady()
    {
        StartCoroutine(UseSkillPlayMotion());
    }

    public virtual IEnumerator UseSkillPlayMotion()
    {
        yield return null;
    }
}
