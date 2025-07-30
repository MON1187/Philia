using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;

// Script create a my mistake name, not normal name is 'Manager' as 'NodeSystem'
public class TestNodeSystem : MonoBehaviour
{
    [Range(0,2)]
    public int _loadNumber;

    public Node[] _node;

    public Node _currentlyNode;

    public Node LoadNextNode(int loadValue)
    {
        return _node[loadValue];
    }
}
