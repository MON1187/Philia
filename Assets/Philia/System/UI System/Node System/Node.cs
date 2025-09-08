using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum NodeType
{
    BattleEvent,
    StoreEvent,
    RandomEvent,
    RestEvenet
};

public class Node : MonoBehaviour
{
    [SerializeField] NodeType _nodeType;

    private Button _myButton;

    public string _name;

    public int _loadBattleSceneId;

    private bool _isAvailability = false;

    [SerializeField] 
    private bool isFrist = false;

    public Node[] _nextNodes;

    [SerializeField] private Node[] _currentNodes;

    [SerializeField]
    private Node _previousNodes;

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

        NodeSystem.Instance.UpdateCurrentNodeData(this);

        _isAvailability = false;

        GetDeactivateNodes(_nextNodes);

        foreach (Node node in _nextNodes)
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
    }

    private void GetDeactivateNodes(Node[] _curNodes)
    {
        for(int i = 0; i < _curNodes.Length; i++)
        {
            _curNodes[i]._currentNodes = new Node[_curNodes.Length];

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
            foreach (Node node in _nextNodes)
            {
                node.GetPreviousNode(this);
                node._isAvailability = true;
            }
            print("ad");
        }

        {
            if(_previousNodes != null)
            _previousNodes._isAvailability = false;

            foreach (Node node in _currentNodes)
            {
                node._isAvailability = false;
            }
        }
    }


    #region A function that calls the next node code from the current node

    public void GetPreviousNode(Node previousNode)
    {
        _previousNodes = previousNode;
    }

    //Calls the function for the first time on all nodes except the current node.
    public void CheckWhetherMove()
    {
        if (!_isAvailability || NodeSystem.Instance.NodeIsMoveing())
            return;

        NodeSystem.Instance.OnPlayerMoveMark(this.transform);

        NodeSystem.Instance.GetTemporaryStorageNode(this);
    }

    public void OnBackMoveMark(Transform playerMark)
    {
        Debug.Log("Ready Back Move");

        StartCoroutine(BackMoveMark(playerMark));
    }

    private IEnumerator BackMoveMark(Transform playerMark)
    {
        NodeSystem.Instance.SetIsMarkNodeMoveing(true);

        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime;

            playerMark.position = Vector3.Lerp(playerMark.position, this.transform.position,time);

            yield return null;
        }

        NodeSystem.Instance.SetIsMarkNodeMoveing(false);
    }

    public void OnNextMoveNode()
    {
        NodeActivation();

        NodeUpdate();

        _previousNodes.NodeActivation();
    }

    #endregion

    #region
    public void LoadEvnetNode()
    {
        if (_nodeType == NodeType.BattleEvent)
        {
            SceneManager.LoadSceneAsync("BattleScene_" + _loadBattleSceneId);
        }
        else if (_nodeType == NodeType.StoreEvent)
        {
            NodeSystem.Instance.OnStoreEvent();
        }
        else if (_nodeType == NodeType.RandomEvent)
        {

        }
        else if (_nodeType == NodeType.RestEvenet)
        {

        }
    }
    #endregion
}