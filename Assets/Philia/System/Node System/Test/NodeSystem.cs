using System.Collections;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;

// Script create a my mistake name, not normal name is 'Manager' as 'NodeSystem'
public class NodeSystem : MonoBehaviour
{
    public static NodeSystem Instance;

    [Range(0,2)]
    public int _loadNumber;

    public Node[] _node;

    public Node _currentlyNode;

    private Node _temporaryStorageNode;

    [SerializeField] private Transform playerNodeMark;

    //public bool nextMoveActivateCheck;

    private void Awake()
    {
        Instance = this;        
    }

    //임시 테스트 업데이트

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            OnSettingsRunningEvent();
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            CheckNextMoveActivate(true);
        }
    }

    #region Call from node
    public void UpdateCurrentNodeData(Node node)
    {
        _currentlyNode = node;
    }

    public void GetTemporaryStorageNode(Node node)
    {
        _temporaryStorageNode = node;
    }
    #endregion

#region Mark Function
    public void SetPlayerMoveMark(Transform pitch)
    {
        playerNodeMark.position = pitch.position;
    }

    public void OnPlayerMoveMark(Transform moveNode)
    {
        StartCoroutine(PlayerMoveMark(moveNode));
    }

    private IEnumerator PlayerMoveMark(Transform targetPos)
    {
        float time = 0;

        while(time < 1)
        {
            time += Time.deltaTime;

            playerNodeMark.position = Vector3.Lerp(playerNodeMark.position, targetPos.position, time);
            yield return null;
        }
    }
    #endregion

#region Before/after event execution

    //After
    public void OnSettingsRunningEvent()
    {
        _currentlyNode = _temporaryStorageNode;

        _temporaryStorageNode = null;
    }

    //Before
    public void CheckNextMoveActivate(bool isActive)
    {
        if (isActive)
        {
            //다음 노드로 이동하는 코드,
            _currentlyNode.OnNextMoveNode();
        }
    }
#endregion
}
