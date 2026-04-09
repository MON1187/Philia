using UnityEngine;

public class TestSlotBTN : MonoBehaviour
{
    public BattleUnitModel owner;

    public void ST_BR()
    {
        owner.OnBattleStart();
        owner.OnTurnFirstStart();
    }

    public void ST_END()
    {
        owner.OnTurnEnd();
    }
}
