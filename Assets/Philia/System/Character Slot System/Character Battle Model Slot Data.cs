using UnityEngine;
using UnityEngine.UI;

public class CharacterBattleModelSlotData : MonoBehaviour
{
    [SerializeField] private BattleUnitModel owner;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.RemoveAllListeners();

        _button.onClick.AddListener(() => PlayerCharacterSlotManager.Instats.SelectCharacterFinalChoice(owner));
    }
}
