using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public enum CardType
{
    attack,
    deffance,
    action
}


public class CardSlot : MonoBehaviour
{
    private CardAbilityBase useSkill;

    [SerializeField] private Image cardTypeIcon;

    [SerializeField] private Image cardImage;

    public AsyncOperationHandle<GameObject> handle;

    public async void OnCheckCardType()
    {
        if (useSkill != null)
        {
            CardType cardType = useSkill.OnGetType();

            switch (cardType)
            {
                case CardType.attack:
                    await GameDataManage.Inst.LoadResourceDataSprite("Attack Icon");
                    break;

                case CardType.deffance:
                    await GameDataManage.Inst.LoadResourceDataSprite("Defance Icon");
                    break;

                case CardType.action:
                    await GameDataManage.Inst.LoadResourceDataSprite("Action Icon");
                    break;
            }
        }
    }
}