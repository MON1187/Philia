using System.Collections;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private Button currentNodeFunctionButton; //After selecting a node, a button to decide whether to execute the event for that node.

    //public bool nextMoveActivateCheck;'

    [SerializeField] private GameObject nodeDescriptionOBj;

    bool nodsIsMoveing = false;

    //Store Obj
    [SerializeField] private GameObject storeCanvas;

    private StoreSystem storeSystem;



    private void Awake()
    {
        Instance = this;

        if (nodeDescriptionOBj != null && nodeDescriptionOBj.activeSelf == true)
            nodeDescriptionOBj.SetActive(false);
         
        if (storeCanvas != null)
            storeSystem = storeCanvas.GetComponent<StoreSystem>();
    }

    //임시 테스트 업데이트

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            B_NodeDescriptionStartEvent();
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

        if(currentNodeFunctionButton!=null)
        {
            //button event set
            currentNodeFunctionButton.onClick.RemoveAllListeners();

            currentNodeFunctionButton.onClick.AddListener(_temporaryStorageNode.LoadEvnetNode);
        }
    }

    public bool NodeIsMoveing()
    {
        return nodsIsMoveing;
    }

    public void OnStoreEvent()
    {
        storeSystem.ResetItemDisplaySlot();
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
        nodsIsMoveing = true;

        float time = 0;

        ActivateNodeInformation();
        while(time < 1)
        {
            time += Time.deltaTime;

            playerNodeMark.position = Vector3.Lerp(playerNodeMark.position, targetPos.position, time);
            yield return null;
        }

        //Passing information about the node and activating the confirmation board
        nodsIsMoveing = false;
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

#region
    private void ActivateNodeInformation()
    {
        nodeDescriptionOBj.gameObject.SetActive(true);
    }
#endregion

#region 
    public void B_NodeDescriptionStartEvent()
    {
        //Event Start Button Code
        OnSettingsRunningEvent();

        CheckNextMoveActivate(this);

        nodeDescriptionOBj.SetActive(false);
    }

    public void B_NodeDescriprtionCheckEvent()
    {

    }
#endregion
}
