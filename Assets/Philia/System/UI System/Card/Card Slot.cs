using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    private CardAbilityBase useSkill;

    public AsyncOperationHandle<GameObject> handle;
}