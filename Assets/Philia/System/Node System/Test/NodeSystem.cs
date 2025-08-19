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

    [SerializeField] private Transform playerNodeMark;


    private void Awake()
    {
        Instance = this;        
    }

    public void UpdateCurrentNodeData(Node node)
    {
        _currentlyNode = node;
    }

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
}
