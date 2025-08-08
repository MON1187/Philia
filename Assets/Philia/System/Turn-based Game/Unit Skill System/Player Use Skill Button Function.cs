using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class PlayerUseSkillButtonFunction : MonoBehaviour
{
    public static PlayerUseSkillButtonFunction Instats;

    [SerializeField] private Button _basic;     //Normal Base Skill

    [SerializeField] private Button _secondary; //Passive or Attack Skill | Sub Skill

    [SerializeField] private Button _ultimate;  //ultimate Skill

    private void Awake()
    {
        //ΩÃ±€≈Ê
        {
            Instats = this;
        }
    }

    /// <summary>
    /// Chagne UI icon and tirgger skill evenet
    /// </summary>
    public void SetSkillUIAll(BattleUnitModel owner)
    {
        SetSkillIcon(owner._basicSkill.icon, owner._secondarySkill.icon, owner._ultimateSkill.icon);

        SetSkillEvent(owner._basicSkill, owner._secondarySkill, owner._ultimateSkill);
    }

    public void SetSkillIcon(Sprite normalSkillIcon, Sprite secondarySkillIcon, Sprite ultimateSkillIcon)
    {
        Image _basicSprite = _basic.gameObject.GetComponent<Image>();

        Image _secondarySprite = _secondary.gameObject.GetComponent<Image>();

        Image _ultimateSprite = _ultimate.gameObject.GetComponent<Image>();

        //Change sprite
        {
            _basicSprite.sprite = normalSkillIcon;

            _secondarySprite.sprite = secondarySkillIcon;

            _ultimateSprite.sprite = ultimateSkillIcon;
        }
    }

    public void SetSkillEvent(SkillAbilityBase basic, SkillAbilityBase secondary, SkillAbilityBase ultimate)
    {
        _basic.onClick.RemoveAllListeners();
        _basic.onClick.AddListener(() => basic.OnUseSkill());

        _secondary.onClick.RemoveAllListeners();
        _secondary.onClick.AddListener(() => secondary.OnUseSkill());

        _ultimate.onClick.RemoveAllListeners();
        _ultimate.onClick.AddListener(() => ultimate.OnUseSkill());
    }
}
