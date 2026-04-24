using JetBrains.Annotations;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    private CardSettingBase useCard;

    public AsyncOperationHandle<GameObject> handle;

    public CardData registeredCardData;


    public void CardDataRegistere(CardData cardData)
    {
        registeredCardData = cardData;
    }
}