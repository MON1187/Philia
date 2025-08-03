using System.Collections;
using UnityEditor.Playables;
using UnityEngine;

//�нú� ��
 
    // ���� ��

    // �ǰ� ��

    // ���� ���� ��

    // ���� ���� ��

    // �� ���� ��

    // �� ��� ��

    // �� ���� ��


//��ų

    // ����

    // ���� ��



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

        //���� ��� ��� �غ� ����
        {
            if (_isReadySkillMotion)
            {
                //���� �Լ� ȣ��
                UseSkillMotionReady();

                return;
            }
        }

        //Ÿ�� ȿ�� ����
        {
            UseSkillEffectAbilityBase();
        }

        //���� ������ �Լ�
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
