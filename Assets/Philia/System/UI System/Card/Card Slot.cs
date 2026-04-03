using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
    attack,
    deffance,
    action
}


public class CardSlot : MonoBehaviour
{
    private SkillAbilityBase useSkill;

    private Image myIcon;

    private void Awake()
    {
        myIcon = GetComponent<Image>();
    }

    public void OnCheckCardType()
    {
        if (useSkill != null)
        {
            CardType cardType = useSkill.OnGetType();

            switch (cardType)
            {
                case CardType.attack:
                    GameDataManage.Inst.LoadResourceDataSprite("Attack Icon", myIcon);
                    break;

                case CardType.deffance:
                    GameDataManage.Inst.LoadResourceDataSprite("Defance Icon", myIcon);
                    break;

                case CardType.action:
                    GameDataManage.Inst.LoadResourceDataSprite("Action Icon", myIcon);
                    break;
            }
        }
    }
}
