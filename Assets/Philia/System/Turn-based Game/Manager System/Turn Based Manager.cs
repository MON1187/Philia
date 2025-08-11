using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TurnBasedManager : MonoBehaviour
{
    public static TurnBasedManager Instats;

    ItemDataAbilityBase[] itemDataAbilityBase;

    public enum State
    {
        Start, End
    }

    public State _state;

    // 0 ~ 3 ��Ʈ�� �÷��̾� ĳ���� ��, 4~ 8������ �� ĳ����
    // ����ȭ �Ҷ� �غ��� ������ ���� ��?

    bool _isPlayerLive;    

    bool _isEnemyLive;    

    public List<BattleUnitModel> playerBattleUnitList = new List<BattleUnitModel>();

    public List<BattleUnitModel> enemyBattleUnitList = new List<BattleUnitModel>();

    private void Awake()
    {
        //�̱���
        {
            Instats = this;
        }

        _state = State.Start;

        //�� ���� �� ������ ����
        {
            PlayerCharacterSlotManager playerCharacterSlotManager = FindAnyObjectByType<PlayerCharacterSlotManager>()?.GetComponent<PlayerCharacterSlotManager>();

            CharacterSlot characterEnemySlot = FindAnyObjectByType<CharacterSlot>()?.GetComponent<CharacterSlot>();

            int fastestSpeed = -999;

            for (int i = 0; i < 4; i++) 
            {
                //List Organize
                {
                    if (playerCharacterSlotManager.LoadSlotUnitModelData(i) != null)
                    {
                        playerBattleUnitList.Add(playerCharacterSlotManager.LoadSlotUnitModelData(i));
                        playerBattleUnitList[i].firstStartRound();
                        //Find the fastest speed and decide which team will start first.
                        {
                            if (playerBattleUnitList[i].GetSpeed() > fastestSpeed)
                            {
                                fastestSpeed = playerBattleUnitList[i].GetSpeed();
                                _state = State.PlayerTurn;
                            }
                        }
                    }
                    if (characterEnemySlot.LoadSlotUnitModelData(i) != null)
                    {
                        enemyBattleUnitList.Add(characterEnemySlot.LoadSlotUnitModelData(i));
                        enemyBattleUnitList[i].firstStartRound();

                        //Find the fastest speed and decide which team will start first.
                        {
                            if (enemyBattleUnitList[i].GetSpeed() > fastestSpeed)
                            {
                                fastestSpeed = enemyBattleUnitList[i].GetSpeed();
                                _state = State.EnemyTurn;
                            }
                        }
                    }
                }

                //Find the fastest speed and decide which team will start first.
                {

                }
            }

            //if (characterData.Length <= 0)
            //{
            //    Debug.LogError("�� ����");
            //    return;
            //}

            if(playerBattleUnitList.Count > 0)
            {
                _isPlayerLive = true;
            }

            if(enemyBattleUnitList.Count > 0)
            {
                _isEnemyLive = true;
            }

            if (!_isEnemyLive || !_isPlayerLive)
            {
#if UNITY_EDITOR
                Debug.LogError($" _isEnemyLive : {_isEnemyLive} |or| _isPlayerLive : {_isPlayerLive}");
#endif
                return;
            }

            //try
            //{
            //    foreach (BattleUnitModel model in characterData)
            //    {
            //        if(model.GetFaction() == faction.Player)
            //        {
            //            playerBattleUnitList.Add(model);
            //        }
            //        else //Enemy
            //        {
            //            enemyBattleUnitList.Add(model);
            //        }
            //    }
            //}
            //catch
            //{
            //    Debug.LogError("Error");
            //}
        }
        
        BattleStart();
    }

    void BattleStart()
    {
        //���� ���� �� ĳ���ͳ� ���� �ִϸ��̼� ȣ�� �� ����
        {
            
        }

        //�� �ѱ�� ����
        {
            OnRoundStart();
        }
    }

    public void OnRoundStart()
    {
        if (_state == State.End)
        {
            EndBattle();
        }

        if (_state == State.PlayerTurn)
        {
            TEST_PlayerAttack();
        }
        else if (_state == State.EnemyTurn)
        {
            StartEnemyTurn();
        }
    }

    public void TEST_PlayerAttack()
    {
        if (_state == State.End)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        playerBattleUnitList[0].StartRound();
        
        yield return new WaitForSeconds(1);

        //���� ����

        playerBattleUnitList[0]._basicSkill.OnUseSkill();

        if (!_isEnemyLive || _state == State.End)
        {
            _state = State.End;
            EndBattle();
        }
        else
        {
            _state = State.EnemyTurn;
            OnRoundStart();
        }
    }

    private void StartEnemyTurn()
    {
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        enemyBattleUnitList[0].StartRound();

        yield return new WaitForSeconds(1);

        //���� ����
        enemyBattleUnitList[0]._basicSkill.OnUseSkill();

        if (!_isPlayerLive || _state == State.End)
        {
            _state = State.End;
            EndBattle();
        }
        else
        {
            _state = State.PlayerTurn;
            OnRoundStart();
        }
    }

    void EndBattle()
    {
        Debug.Log("End Game");
        return;
    }

    public void RemoveBattleUnitModel(BattleUnitModel model)
    {
        if(model.GetFaction() == faction.Player)
        {
            playerBattleUnitList.Remove(model);
            CheckEveryoneDead(playerBattleUnitList);
        }
        else //Enemy
        {
            enemyBattleUnitList.Remove(model);
            CheckEveryoneDead(enemyBattleUnitList);
        }

    }

    public void CheckEveryoneDead(List<BattleUnitModel> models)
    {
        if (models.Count > 0)
        {
            return;
        }

        _state = State.End;
    }
}
