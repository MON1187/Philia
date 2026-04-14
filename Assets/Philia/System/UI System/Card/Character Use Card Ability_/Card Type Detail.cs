using UnityEngine;
using UnityEngine.UI;

public enum CardTypeDetail
{
    Attake,
    Deffance,
    Action
}

public class CardTypeInformationDetail : MonoBehaviour
{
    public Image typeIcon;

    public string rink = AddressableResourceRink.Battle_UX;

    private CardAbilityBase useSkill;

    public void SetCardTypeResource(CardAbilityBase useCardSkil)
    {
        this.useSkill = useCardSkil;

        OnCheckCardType();
    }

    public async void OnCheckCardType()
    {
        if (useSkill != null)
        {
            CardTypeDetail cardType = useSkill.OnGetType();

            switch (cardType)
            {
                case CardTypeDetail.Attake:
                    await GameDataManage.Inst.LoadResourceDataSprite("Attack Icon");
                    break;

                case CardTypeDetail.Deffance:
                    await GameDataManage.Inst.LoadResourceDataSprite("Defance Icon");
                    break;

                case CardTypeDetail.Action:
                    await GameDataManage.Inst.LoadResourceDataSprite("Action Icon");
                    break;
            }
        }
    }
}