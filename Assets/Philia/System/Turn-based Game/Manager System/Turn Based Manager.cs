using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TurnBasedManager : MonoBehaviour
{
    public static TurnBasedManager Instats;

    public enum State
    {
        Start, PlayerTurn, EnemyTurn, End
    }

    public State _state;

    // 0 ~ 3 ��Ʈ�� �÷��̾� ĳ���� ��, 4~ 8������ �� ĳ����
    // ����ȭ �Ҷ� �غ��� ������ ���� ��?

    bool _isPlayerLive;    

    bool _isEnemyLive;    

    //�ӽ� �� : 0�� �÷��̾�, 1�� ��
    public BattleUnitModel[] characterData;

    private List<BattleUnitModel> playerBattleUnitList = new List<BattleUnitModel>();

    private List<BattleUnitModel> enemyBattleUnitList = new List<BattleUnitModel>();

    private void Awake()
    {
        //�̱���
        {
            Instats = this;

        }

        //�� ���� �� ������ ����
        {
            if (characterData.Length <= 0)
            {
                Debug.LogError("�� ����");
                return;
            }

            _isPlayerLive = true;

            _isEnemyLive = true;

            try
            {
                foreach (BattleUnitModel model in characterData)
                {
                    if(model.GetFaction() == faction.Player)
                    {
                        playerBattleUnitList.Add(model);
                    }
                    else //Enemy
                    {
                        enemyBattleUnitList.Add(model);
                    }
                }
            }
            catch
            {
                Debug.LogError("Error");
            }
        }
        
        
        _state = State.Start;

        BattleStart();
    }

    void BattleStart()
    {
        //���� ���� �� ĳ���ͳ� ���� �ִϸ��̼� ȣ�� �� ����
        {

        }

        //�� �ѱ��
        {
            _state = State.PlayerTurn;
            Debug.Log("Start Turn : " +  _state);
        }
    }

    public void TEST_PlayerAttack()
    {
        Debug.Log("Round");

        if (_state == State.End)
        {
            return;
        }

        Debug.Log("����!");
        
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(1);

        //���� ����

        int takeRandomDamage = Random.Range(1, 3);

        characterData[1].TakeDamage(takeRandomDamage);

        Debug.Log("�� �� ����! : " + takeRandomDamage);

        yield return new WaitForSeconds(1);

        if (!_isEnemyLive)
        {
            _state = State.End;
            EndBattle();
        }
        else
        {
            _state = State.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("���� ��!");

        yield return new WaitForSeconds(1);

        //���� ����
        int takeRandomDamage = Random.Range(1, 2);

        characterData[0].TakeDamage(takeRandomDamage);

        Debug.Log("�� �� ����! : " + takeRandomDamage);

        yield return new WaitForSeconds(1);

        //
        if (!_isPlayerLive)
        {
            _state = State.End;
            EndBattle();
        }
        else
        {
            _state = State.PlayerTurn;

            Debug.Log("�÷��̾� ��!");
        }
 
    }

    void EndBattle()
    {
        Debug.Log("End Tun");
    }

    public void RemoveBattleUnitModel(BattleUnitModel model)
    {
        if(model.GetFaction() == faction.Player)
        {
            playerBattleUnitList.Remove(model);
        }
        else //Enemy
        {
            enemyBattleUnitList.Remove(model);
        }
    }
}
