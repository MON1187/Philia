using UnityEngine;
using UnityEngine.UI;

public class CharacterBattleModelSlotData : MonoBehaviour
{
    [SerializeField] private BattleUnitModel owner;

    [SerializeField] private GameObject useItemCloseMarge;

    private Button _button;

    public bool isUseSlot;



    private void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.RemoveAllListeners();

        _button.onClick.AddListener(() => PlayerCharacterSlotManager.Instats.SelectCharacterFinalChoice(owner));

        _button.onClick.AddListener(() => PlayerCharacterSlotManager.Instats.IsActiveWhether(this));

        _button.onClick.AddListener(() => UseSlot());
    }

    private void UseSlot()
    {
        isUseSlot = true;
    }

    private void UnUseSlot()
    {
        isUseSlot = false;
    }

    public void UpdateSlotUseWhether()
    {
        if (isUseSlot)
        {
            useItemCloseMarge.SetActive(true);
        }
        else
        {
            useItemCloseMarge.SetActive(false);
        }
    }
}
