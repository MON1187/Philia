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

    // 0 ~ 3 비트는 플레이어 캐릭터 군, 4~ 8까지는 적 캐릭터
    // 최적화 할때 해봐도 나쁘지 않을 듯?

    bool _isPlayerLive;    

    bool _isEnemyLive;    

    //임시 값 : 0은 플레이어, 1은 적
    public BattleUnitModel[] characterData;

    private List<BattleUnitModel> playerBattleUnitList = new List<BattleUnitModel>();

    private List<BattleUnitModel> enemyBattleUnitList = new List<BattleUnitModel>();

    private void Awake()
    {
        //싱글톤
        {
            Instats = this;

        }

        //턴 시작 전 데이터 정리
        {
            if (characterData.Length <= 0)
            {
                Debug.LogError("모델 없음");
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
        //전투 시작 시 캐릭터나 등장 애니메이션 호출 용 공간
        {

        }

        //턴 넘기기
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

        Debug.Log("공격!");
        
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(1);

        //공격 실행

        int takeRandomDamage = Random.Range(1, 3);

        characterData[1].TakeDamage(takeRandomDamage);

        Debug.Log("나 의 공격! : " + takeRandomDamage);

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
        Debug.Log("적의 턴!");

        yield return new WaitForSeconds(1);

        //공격 실행
        int takeRandomDamage = Random.Range(1, 2);

        characterData[0].TakeDamage(takeRandomDamage);

        Debug.Log("적 의 공격! : " + takeRandomDamage);

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

            Debug.Log("플레이어 턴!");
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
