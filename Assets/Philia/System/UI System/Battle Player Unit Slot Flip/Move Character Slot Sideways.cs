using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class MoveCharacterSlotSideways : MonoBehaviour
{
    [SerializeField] private Transform[] movePoint;

    [SerializeField] private int slotIndex;

    private Vector2 startPos;

    private bool isDragging = false;

    bool isSlotMove = false;

    int size {
        get => TurnBasedManager.Instats.playerBattleUnitList.Count - 1;
    }

    private void Start()
    {
        if(size != 0)
        SetHideCharacterImage();
    }

    void Update()
    {
        // 드래그 시작
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isDragging = true;
        }

        // 드래그 중
        if (isDragging && Input.GetMouseButton(0) && !isSlotMove)
        {
            Vector2 currentPos = Input.mousePosition;
            float direction = currentPos.x - startPos.x;

            bool isRight = direction < startPos.x;

            //연출 공간
            {
                if (size > 0) { 
                    if (!isSlotMove && Mathf.Abs(direction) > 250f)
                    {
                        isSlotMove = true;
                        IsMoveSlot(isRight);
                    }
                }

            }
        }

        // 드래그 종료
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    private void IsMoveSlot(bool isRight)
    {
        Debug.Log("is drag");
        if (isCheckNextCharacterSlot(isRight))
        {
            StartCoroutine(IsMoveingSlot(TurnBasedManager.Instats.playerBattleUnitList[slotIndex].gameObject, movePoint[2].transform));

            slotIndex += 1;

            StartCoroutine(IsNextMoveSlot(TurnBasedManager.Instats.playerBattleUnitList[slotIndex].gameObject, movePoint[1].transform));
        }
        else if (isCheckNextCharacterSlot(!isRight))
        {
            StartCoroutine(IsMoveingSlot(TurnBasedManager.Instats.playerBattleUnitList[slotIndex].gameObject, movePoint[0].transform));

            slotIndex -= 1;

            StartCoroutine(IsNextMoveSlot(TurnBasedManager.Instats.playerBattleUnitList[slotIndex].gameObject, movePoint[1].transform));
        }
    }

    private IEnumerator IsMoveingSlot(GameObject objectMove, Transform movePoint)
    {
        float time = 1;

        float curTime = 0;

        Transform moveObject = objectMove.GetComponent<Transform>();

        while(curTime < time)
        {
            curTime += Time.deltaTime;

            moveObject.position = Vector3.Lerp(moveObject.position, movePoint.position, curTime);
            yield return null;
        }

        isSlotMove = false;
    }

    private IEnumerator IsNextMoveSlot(GameObject objectMove, Transform movePoint)
    {
        float time = 1;

        float curTime = 0;

        Transform moveObject = objectMove.GetComponent<Transform>();

        while (curTime < time)
        {
            curTime += Time.deltaTime;

            moveObject.position = Vector3.Lerp(moveObject.position, movePoint.position, curTime);
            yield return null;
        }
    }

    private bool isCheckNextCharacterSlot(bool isRight)
    {
        if (isRight)
        {
            if (slotIndex >= 0 && slotIndex < size) 
                return true;
            else 
                return false;
        }
        else
        {
            if (slotIndex <= 0)
                return false;
            else
                return true;
        }
    }

    //First moveing character hide and next character call see.
    private void OnHideCharacterImage()
    {
        StartCoroutine(HideCharacterImage());
    }

    private IEnumerator HideCharacterImage()
    {
        float time = 1;

        float curTime = 0;

        yield return null;
    }

    //First character excepiton and remainder character hide
    private void SetHideCharacterImage()
    {
        Image[] character = new Image[size -1];
        
        //Get image work
        {
            for(int i = 1; i < size; i++)
            {
                character[i - 1] = TurnBasedManager.Instats.playerBattleUnitList[i].gameObject.GetComponent<Image>();
            }
        }

        //hide image work
        {
            foreach(Image image in character)
            {
                Color color = image.color;
                color.a = 0;
                
                image.color = color;
            }
        }
    }
}
