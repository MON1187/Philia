using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniNode : MonoBehaviour
{
    //NodeType _nodeType;

    private Button _myButton;

    public string _name;

    public int _loadBattleSceneId;

    private bool _isAvailability = false;

    [SerializeField] private bool isFrist = false;

    public MiniNode[] _nextNodes;

    private MiniNode[] _currentNodes;

    [SerializeField] private MiniNode _previousNodes;

    private void Start()
    {
        _myButton = GetComponent<Button>();
        {
            if (isFrist)
                FirstSettingNode();
            else
                _myButton.onClick.AddListener(CheckWhetherMove);
        }
    }

    private void FirstSettingNode()
    {
        NodeSystem.Instance.SetPlayerMoveMark(this.gameObject.transform);

        _isAvailability = false;

        foreach (MiniNode node in _nextNodes)
        {
            node.GetPreviousNode(this);
            node._isAvailability = true;
        }
    }


    void NodeActivation()
    {
        if (!_isAvailability)
            return;

        GetDeactivateNodes(_nextNodes);

        //���� ������ �Ѿ�� �ڵ� �ۼ�

    }

    private void GetDeactivateNodes(MiniNode[] _curNodes)
    {
        for (int i = 0; i < _curNodes.Length; i++)
        {
            _curNodes[i]._currentNodes = new MiniNode[_curNodes.Length];

            _curNodes[i]._currentNodes = _curNodes;
        }
    }

    /// <summary>
    /// After the battle process is over, if you win, run the code below
    /// Function terminates upon defeat.
    /// </summary>
    private void NodeUpdate()
    {
        if (_isAvailability)
        {
            foreach (MiniNode node in _nextNodes)
            {
                node.GetPreviousNode(this);
                node._isAvailability = true;
            }
            print("ad");
        }

        {
            this._isAvailability = false;

            foreach (MiniNode node in _currentNodes)
            {
                node._isAvailability = false;
            }
        }
    }


    #region A function that calls the next node code from the current node

    public void GetPreviousNode(MiniNode previousNode)
    {
        _previousNodes = previousNode;
    }

    public void CheckWhetherMove()
    {
        if (!_isAvailability)
            return;

        NodeSystem.Instance.OnPlayerMoveMark(this.transform);
    }

    public void OnBackMoveMark(Transform playerMark)
    {
        StartCoroutine(BackMoveMark(playerMark));
    }

    private IEnumerator BackMoveMark(Transform playerMark)
    {
        float time = 0;

        if (time < 0)
        {
            time += Time.deltaTime;

            playerMark.position = Vector3.Lerp(playerMark.position, _previousNodes.transform.position, time);

            yield return null;
        }
    }

    #endregion
}