using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PhiliaBasiceSkill : SkillAbilityBase
{
    protected override void UseSkillAbilityBase(BattleUnitModel target)
    {
        Debug.Log("use");
        owner.InflictDamage(59, target);
    }
}
