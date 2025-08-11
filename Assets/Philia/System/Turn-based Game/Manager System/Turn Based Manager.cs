using NUnit.Framework;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
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

    // 0 ~ 3 비트는 플레이어 캐릭터 군, 4~ 8까지는 적 캐릭터
    // 최적화 할때 해봐도 나쁘지 않을 듯?

    bool _isPlayerLive;    

    bool _isEnemyLive;    

    public List<BattleUnitModel> playerBattleUnitList = new List<BattleUnitModel>();

    public List<BattleUnitModel> enemyBattleUnitList = new List<BattleUnitModel>();

    public List<BattleUnitModel> playTurnCharacterUnitList = new List<BattleUnitModel>();

    private void Awake()
    {
        //추상화
        {
            Instats = this;
        }

        _state = State.Start;

        //턴 시작 전 데이터 정리
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
            //    Debug.LogError("모델 없음");
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

        SetBattleUnitmodelPlayTurnList();

        BattleStart();
    }

    void BattleStart()
    {
        //전투 시작 시 캐릭터나 등장 애니메이션 호출 용 공간
        {
            
        }

        //턴 넘기며 시작
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

        StartRoundUnitModelPlayTurnList();

            //PlayerUseSkillButtonFunction.Instats.B_SetSkillIconAll();
        StartPlayerTurn();
        StartEnemyTurn();
    }

    private void SetBattleUnitmodelPlayTurnList()
    {
        //At the start, combine the lists into one, then select a turn based on speed.

        for (int i = 0; i< playerBattleUnitList.Count; i++)
            playTurnCharacterUnitList.Add(playerBattleUnitList[i]);

        for (int i = 0; i < enemyBattleUnitList.Count; i++)
            playTurnCharacterUnitList.Add(enemyBattleUnitList[i]);
    }

    private void StartRoundUnitModelPlayTurnList()
    {
        int listSize = playTurnCharacterUnitList.Count;

        BobuleSrot(playTurnCharacterUnitList, listSize);
    }

    private void BobuleSrot(List<BattleUnitModel> list, int size)
    {
        int i, j;

        BattleUnitModel temp;

        //속도가 제일 느린 모델부터 순차적으로 배치
        for (i = size - 1; i > 0; i--)
        {
            // 0 ~ (i-1)까지 반복
            for (j = 0; j < i; j++)
            {
                // j번째와 j+1번째의 요소가 크기 순이 아니면 교환
                if (list[j].GetSpeed() < list[j + 1].GetSpeed())
                {
                    temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }

        //List 뒤집기
        list.Reverse();

        ////테스트용 디버그
        //for (i = 0; i < list.Count; i++)
        //{
        //    print(list[i].name);
        //}
    }

#region Player Turn

    public void StartPlayerTurn()
    {
        if (_state == State.End)
        {
            return;
        }

        StartCoroutine(PlayerTurn());
    }

    IEnumerator PlayerTurn()
    {
        //foreach (BattleUnitModel owner in playerBattleUnitList)
        //{
        //    owner.StartRound();
        //}

        UnitStartRound(playerBattleUnitList);

        PlayerUseSkillButtonFunction.Instats.SetSkillUIAll(playerBattleUnitList[0]);

        bool isActionEnd = false;

        //턴 끝났는지 체크
        while (!isActionEnd)
        {
            bool isAllAction = true;

            foreach (BattleUnitModel owner in playerBattleUnitList)
            {
                if (!owner.isReady)
                {
                    isAllAction = false;
                    Debug.Log("! 아직 준비 안됨");
                    break;
                }
            }
            
            if (isAllAction)
            {
                isActionEnd = true;
                Debug.Log("준비 완료");
                break;
            }

            yield return new WaitForSeconds(.25f);
        }

        //배틀 시작되는 연출

        PlayBattleUnitSkillAll();
    }

    #endregion

#region Enemy Turn

    private void StartEnemyTurn()
    {
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        //Start Round
        //enemyBattleUnitList[0].StartRound();
        UnitStartRound(enemyBattleUnitList);

        yield return new WaitForSeconds(1);

        //공격 실행
        //enemyBattleUnitList[0]._basicSkill.OnUseSkill();

        AutoPlayEnemyTurn();
    }

    private void AutoPlayEnemyTurn()
    {
        for (int i = 0; i < enemyBattleUnitList.Count; i++)
        {
            enemyBattleUnitList[i]._basicSkill.UseSkillReady();
        }
    }

#endregion

    private void UnitStartRound(List <BattleUnitModel> owner)
    {
        foreach (BattleUnitModel model in owner)
            model.StartRound();
    }

    private void PlayBattleUnitSkillAll()
    {
        StartCoroutine(OnPlayBattleUnitSkillAll());
    }

    private IEnumerator OnPlayBattleUnitSkillAll()
    {
        for(int i = 0; i < playTurnCharacterUnitList.Count; i++)
        {
            print(playTurnCharacterUnitList[i].name + "의 턴 진행");

            UseSkillData useSkillData = playTurnCharacterUnitList[i].GetUseSkillData();

            useSkillData.useSkill.OnUseSkill();

            yield return new WaitForSeconds(useSkillData.playSkillProductionTime);

            if (!_isPlayerLive || _state == State.End)
            {
                _state = State.End;
                EndBattle();
            }
            else
            {
                OnRoundStart();
            }
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
