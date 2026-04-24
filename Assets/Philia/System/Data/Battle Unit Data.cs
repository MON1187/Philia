using UnityEngine;

[CreateAssetMenu(fileName = "New Battle Unit Data", menuName = "Philia Assets/Character Assets/New Character Data")]
public class BattleUnitData : ScriptableObject
{
    public int id = 10000;

    public string name;

    public int st_MaxHealth;
    public int st_MinHealth = 0;

    public int st_MaxBreakLife;
    public int st_MinBreakLife = 0;

    public int st_Speed;

    public int st_Strong;

    public int st_MaxActionPoint;
    public int st_StartActionPoint;
}