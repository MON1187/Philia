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

        //���� ������ �Ѿ�� �ڵ� �ۼ�


        //���� ������ ���� ����, �¸��� �Ʒ� �ڵ� ����
        //�й� �� �Լ� ����.
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

