using UnityEngine;
using UnityEngine.UI;

enum NodeType
{
    A,
    B,
    C
};

public class Node : MonoBehaviour
{
    //NodeType _nodeType;

    private Button _myButton;

    public string _name;

    public int _loadBaatleSceneId;

    public bool _isAvailability = false;

    public Node[] _nextNodes;

    private Node[] _currentNodes;

    private void Start()
    {
        _myButton = GetComponent<Button>();

        _myButton.onClick.AddListener(Test);
    }

    void Test()
    {
        if (!_isAvailability)
            return;

        GetDeactivateNodes(_nextNodes);

        //전투 씬으로 넘어가는 코드 작성


        //전투 과정이 끝난 다음, 승리시 아래 코드 실행
        //패배 시 함수 종료.
        if (_isAvailability)
        {
            foreach (Node node in _nextNodes)
            {
                node._isAvailability = true;
            }
            print("ad");
        }

        {
            this._isAvailability = false;

            foreach (Node node in _currentNodes)
            {
                node._isAvailability = false;
            }
        }
    }

    private void GetDeactivateNodes(Node[] _curNodes)
    {
        for(int i = 0; i < _curNodes.Length; i++)
        {
            _curNodes[i]._currentNodes = new Node[_curNodes.Length];

            _curNodes[i]._currentNodes = _curNodes;
        }
    }
}

