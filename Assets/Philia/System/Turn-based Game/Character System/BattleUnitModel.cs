using System;
using UnityEngine;

public enum faction
{
    Player,
    Enemy
}

public class BattleUnitModel : MonoBehaviour
{

    [SerializeField] private faction _faction;

    [SerializeField] private BattleUnitData _unitData;

    public faction GetFaction() { return _faction; }

    public void TakeDamage(int dmg)
    {
        _unitData.st_Health -= dmg;

        if (_unitData.st_Health < 0)
        {
            TurnBasedManager.Instats.RemoveBattleUnitModel(this);

            //�׾��� �� ���� ����
            {

            }

            return;
        }

        TESTDEBUG();
    }

    private void TESTDEBUG()
    {
        Debug.Log("���� ü�� : " + _unitData.st_Health);
    }
}


[Serializable]
public class BattleUnitData
{
    public int st_Health;
    public int st_Break;

    public int st_MaxActionPoint;
    public int st_StartActionPoint;
}