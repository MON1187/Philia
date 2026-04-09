using UnityEngine;

public class TestPassive : PassiveAbilityBase
{
    public int index;

    public override int UseSkillSlotAdder()
    {
        return index;
    }
}
